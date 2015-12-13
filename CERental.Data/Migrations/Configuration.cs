using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace CERental.Data.Migrations
{
    public class Configuration : DbMigrationsConfiguration<CERentalDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(CERentalDbContext context)
        {
            new CERentalDBSeeder().Seed(context);
        }
    }

    public class CERentalDbInitialize : CreateDatabaseIfNotExists<CERentalDbContext>
    {
        protected override void Seed(CERentalDbContext context)
        {
            new CERentalDBSeeder().Seed(context);
        }
    }
}