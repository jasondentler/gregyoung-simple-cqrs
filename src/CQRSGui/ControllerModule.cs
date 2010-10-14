using System.Web.Mvc;
using Ninject;
using Ninject.Modules;

namespace CQRSGui
{
    public class ControllerModule : NinjectModule 
    {

        public override void Load()
        {
            ControllerBuilder.Current.SetControllerFactory(
                Kernel.Get<NinjectControllerFactory>());

        }

    }
}