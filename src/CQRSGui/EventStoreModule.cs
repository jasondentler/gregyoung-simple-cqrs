using Ninject.Modules;
using SimpleCQRS.EventStore;
using SimpleCQRS.EventStore.NHibernate;

namespace CQRSGui
{
    public class EventStoreModule : NinjectModule 
    {

        public override void Load()
        {
            Kernel.Bind<IEventStore>().To<NHibernateEventStore>();
        }

    }
}