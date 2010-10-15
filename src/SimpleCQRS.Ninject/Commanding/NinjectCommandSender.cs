using Ninject;

namespace SimpleCQRS.Commanding
{
    public class NinjectCommandSender : ICommandSender
    {
        private readonly IKernel _kernel;
        
        public NinjectCommandSender(IKernel kernel)
        {
            _kernel = kernel;
        }

        public void Send<T>(T command) where T : Command
        {
            var handler = _kernel.Get<IHandles<T>>();
            handler.Handle(command);
        }

    }
}
