using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using CERental.ApplicationServices.Services;
using CERental.Core.Contract.Services;

namespace CERental.Web.Public.Windsor.Installers
{
    public class ServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Types.FromAssemblyContaining(typeof(RentalService))
                    .BasedOn<IApplicationService>()
                    .WithService.FromInterface()
                    .LifestyleTransient()

                    //Types.FromAssemblyContaining(typeof(DeviceService))
                    //.BasedOn<ISingletonService>()
                    //.WithService.FromInterface()
                    //.LifestyleSingleton()
                );
        }
    }
}