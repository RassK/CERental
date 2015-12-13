using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using CERental.Core.Contract;
using CERental.Core.Contract.Repository;
using CERental.Data;
using CERental.Data.Repositories;

namespace CERental.Server.Windsor
{
    public class DalInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IDbContext>()
                    .ImplementedBy<CERentalDbContext>()
                    .LifestyleTransient(),

               // Repositories
               Classes.FromAssemblyContaining(typeof(EquipmentRepository))
                   .BasedOn<IRepository>()
                   .WithService.FromInterface()
                   .LifestyleTransient()
                );
        }
    }
}