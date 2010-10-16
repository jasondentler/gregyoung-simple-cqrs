using Ninject.Modules;
using SimpleCQRS.Domain;

namespace CQRSGui.GuyWire
{
    public class RepositoryModule : NinjectModule 
    {

        public override void Load()
        {
            Kernel.Bind(typeof (IRepository<>))
                .To(typeof (Repository<>));
        }

    }
}