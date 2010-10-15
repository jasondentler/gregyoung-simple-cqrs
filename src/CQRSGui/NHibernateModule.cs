using NHibernate;
using NHibernate.Cfg;
using Ninject.Modules;

namespace CQRSGui
{
    public class NHibernateModule : NinjectModule 
    {

        public override void Load()
        {
            var cfg = new Configuration().Configure();
            var sessionFactory = cfg.BuildSessionFactory();

            Kernel.Bind<IStatelessSession>()
                .ToMethod(ctx => sessionFactory.OpenStatelessSession());

        }

    }
}