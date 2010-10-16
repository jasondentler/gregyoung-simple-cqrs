using Ninject.Modules;
using SimpleCQRS.EventStore;
using SimpleCQRS.EventStore.NHibernate;

namespace CQRSGui.GuyWire
{
    public class EventStoreModule : NinjectModule 
    {

        public override void Load()
        {
            Kernel.Bind<IEventStore>().To<NHibernateEventStore>();
        }

    }
}