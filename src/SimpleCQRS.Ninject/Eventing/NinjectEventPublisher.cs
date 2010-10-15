using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using log4net;
using Ninject;

namespace SimpleCQRS.Eventing
{
    public class NinjectEventPublisher : IEventPublisher
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof (NinjectEventPublisher));

        private delegate void PublishDelegate<T>(T @event) where T : Event;

        private readonly IKernel _kernel;
        private readonly ConcurrentDictionary<Type, Delegate> _map;

        public NinjectEventPublisher(IKernel kernel)
        {
            _kernel = kernel;
            _map = new ConcurrentDictionary<Type, Delegate>();
        }

        public void Publish<T>(T @event) where T : Event
        {
            if (typeof(T) == typeof(Event))
            {
                // Called with Publish<Event>
                // Should be called with Publish<SpecificEventType>
                InvokePublishCorrectly(@event);
                return;
            }

            var handlers = _kernel.GetAll<IHandles<T>>();

            Log.DebugFormat("{0} handlers for {1}",
                            handlers.Count(), @event.GetType().Name);

            foreach (var handler in handlers)
            {
                Log.DebugFormat("{0} handling {1}",
                                handler.GetType().Name, @event.GetType().Name);
                var handler1 = handler;
                ThreadPool.QueueUserWorkItem(x => handler1.Handle(@event));
            }
        }

        private void InvokePublishCorrectly(Event @event)
        {
            var eventType = @event.GetType();
            // Get the cached delegate, or build one
            Delegate d = _map.GetOrAdd(eventType, CreateDelegate);
            // Call Publish<SpecificEventType>
            d.DynamicInvoke(@event);
        }

        private Delegate CreateDelegate(Type eventType)
        {
            var mi = typeof (NinjectEventPublisher)
                .GetMethod("Publish")
                .MakeGenericMethod(eventType);
            var delegateType = typeof (PublishDelegate<>)
                .MakeGenericType(eventType);
            return Delegate.CreateDelegate(delegateType, this, mi);
        }

    }
}
