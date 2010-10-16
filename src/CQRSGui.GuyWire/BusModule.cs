using System.Linq;
using System.Reflection;
using log4net;
using Ninject.Modules;
using SimpleCQRS;
using Ninject;
using SimpleCQRS.Commanding;
using SimpleCQRS.Eventing;
using SimpleCQRS.Example.CommandHandlers;

namespace CQRSGui.GuyWire
{
    public class BusModule : NinjectModule 
    {

        private static readonly ILog Log = LogManager.GetLogger(typeof (BusModule));

        public override void Load()
        {
            Kernel.Bind<ICommandSender>()
                .To<NinjectCommandSender>()
                .InSingletonScope();

            Kernel.Bind<IEventPublisher>()
                .To<NinjectEventPublisher>()
                .InSingletonScope();

            RegisterHandlers(
                Assembly.GetAssembly(typeof (InventoryCommandHandlers)));
        }

        private void RegisterHandlers(params Assembly[] asms)
        {
            var allTypes = asms
                .Distinct()
                .SelectMany(asm => asm.GetTypes());
            var allConcreteTypes = allTypes.Where(t => t.IsClass && !t.IsAbstract);
            var interfaceMap = allConcreteTypes
                .Select(t => new {impl = t, services = t.GetInterfaces()})
                .SelectMany(item => item.services, (item, service) =>
                                                   new {item.impl, service})
                .Where(map => map.service.IsGenericType &&
                              map.service.GetGenericTypeDefinition() == typeof (IHandles<>));

            foreach (var mapping in interfaceMap)
            {
                var mapping1 = mapping;
                Log.DebugFormat("{0} handles {1}",
                                mapping1.impl.Name,
                                mapping1.service.GetGenericArguments()[0].Name);

                Kernel.Bind(mapping.service)
                    .ToMethod(ctx => ctx.Kernel.Get(mapping1.impl));
            }
        }

    }
}