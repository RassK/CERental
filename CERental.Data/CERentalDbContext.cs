using System.Data.Entity;
using CERental.Core.Contract;
using CERental.Core.Domain;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CERental.Data
{
    public class CERentalDbContext : IdentityDbContext<ApplicationUser>, IDbContext
    {
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<EquipmentInRent> EquipmentsInRent { get; set; }
        public DbSet<Rental> Rentals { get; set; }

        public CERentalDbContext()
            : base("name=DefaultConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            /* Configure ASP.NET base */
            base.OnModelCreating(modelBuilder);

            /* Configure tables base */
            var users = modelBuilder.Entity<ApplicationUser>().ToTable("Users");
            var usersInRole = modelBuilder.Entity<IdentityUserRole>().ToTable("UserInRole");
            var loginProviders = modelBuilder.Entity<IdentityUserLogin>().ToTable("LoginProviders");
            var claims = modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaims");
            var roles = modelBuilder.Entity<IdentityRole>().ToTable("Roles");

            var equipmentInRental = modelBuilder.Entity<EquipmentInRent>().ToTable("EquipmentsInRent");
            var equipments = modelBuilder.Entity<Equipment>().ToTable("Equipments");
            var rentals = modelBuilder.Entity<Rental>().ToTable("Rentals");

            users.HasMany(x => x.Rentals).WithRequired(x => x.User).HasForeignKey(x => x.UserId);

            equipments.Property(x => x.Name).IsRequired();
            equipments.Property(x => x.Type).IsRequired();
            equipments.HasMany(x => x.EquipmentInRent).WithRequired(x => x.Equipment).HasForeignKey(x => x.EquipmentId);

            rentals.HasMany(x => x.EquipmentsInRent).WithRequired(x => x.Rental).HasForeignKey(x => x.RentalId);
        }
    }
}