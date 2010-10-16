using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using log4net;
using Ninject;

namespace CQRSGui
{
    public class NinjectControllerFactory : DefaultControllerFactory 
    {

        private readonly IKernel _kernel;

        public static readonly ILog Log = LogManager.GetLogger(typeof (NinjectControllerFactory));

        public NinjectControllerFactory(IKernel kernel)
        {
            _kernel = kernel;
        }

        protected override IController GetControllerInstance(
            RequestContext requestContext, Type controllerType)
        {

            if (controllerType == null)
            {
                Log.WarnFormat("No controller for path '{0}'",
                               requestContext.HttpContext.Request.Path);
                throw new HttpException(
                    404,
                    string.Format("{0} not found.",
                                  requestContext.HttpContext.Request.Path));
            }

            if (!typeof(IController).IsAssignableFrom(controllerType))
            {
                Log.ErrorFormat("Type requested is not a controller: {0}",
                    controllerType);
                throw new HttpException(
                    500,
                    string.Format("It's not you, it's me."));
            }

            return _kernel.Get(controllerType) as IController
                   ?? base.GetControllerInstance(requestContext, controllerType);

        }

    }
}