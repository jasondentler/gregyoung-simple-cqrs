using Ninject.Modules;
using SimpleCQRS;
using SimpleCQRS.Domain;

namespace CQRSGui
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