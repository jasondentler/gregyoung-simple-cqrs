using Ninject;
using Ninject.Modules;

namespace CQRSGui.GuyWire
{
    public class KernelRegistrationModule : NinjectModule 
    {

        public override void Load()
        {
            Kernel.Bind<IKernel>()
                .ToConstant(Kernel);
        }

    }
}