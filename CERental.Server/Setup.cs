using Castle.Windsor;
using Castle.Windsor.Installer;
using CERental.Core;

namespace CERental.Server
{
    public class Setup
    {
        public static void Run()
        {
            SetupWindsor();
        }

        private static void SetupWindsor()
        {
            var _container = new WindsorContainer()
                .Install(FromAssembly.This());

            IoC.Setup(x => _container.Resolve(x));
            IoC.SetContainer(_container);
        }
    }
}