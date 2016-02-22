namespace LostPets.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<LostPetsDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(LostPetsDbContext context)
        {
            var seeder = new SeedData(context);
            seeder.Seed(context);
        }
    }
}
