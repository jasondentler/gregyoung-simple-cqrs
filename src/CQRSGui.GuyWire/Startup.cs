using System.Web.Mvc;
using System.Web.Routing;
using GuyWire;
using NHibernate;
using NHibernate.Cfg;
using Ninject;

namespace CQRSGui.GuyWire
{
	public class Startup : IGuyWire 
	{
		public void Wire()
		{
			var kernel = ConfigureNinject();
			ConfigureLog4Net();
			ConfigureRouting();
			ConfigureNHibernate(kernel);
			ConfigureControllerBuilder(kernel);
		}

		private static IKernel ConfigureNinject()
		{
			return new StandardKernel(
				new KernelRegistrationModule(),
				new BusModule(),
				new EventStoreModule(),
				new RepositoryModule());
		}

		private static void ConfigureLog4Net()
		{
			log4net.Config.XmlConfigurator.Configure();
		}

		private static void ConfigureRouting()
		{
			AreaRegistration.RegisterAllAreas();
			var routes = RouteTable.Routes;
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico" });

			routes.MapRoute(
				"Default", // Route name
				"{controller}/{action}/{id}", // URL with parameters
				new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
			);

		}

		private static void ConfigureNHibernate(IKernel kernel)
		{
			var cfg = new Configuration().Configure();
			var sessionFactory = cfg.BuildSessionFactory();

			kernel.Bind<IStatelessSession>()
				.ToMethod(ctx => sessionFactory.OpenStatelessSession());
		}

		private static void ConfigureControllerBuilder(IKernel kernel)
		{
			ControllerBuilder.Current.SetControllerFactory(
				kernel.Get<NinjectControllerFactory>());
		}

	}
}
