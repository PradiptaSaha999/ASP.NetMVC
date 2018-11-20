namespace demoForm.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<demoForm.Models.Survey>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "demoForm.Models.Survey";
        }

        protected override void Seed(demoForm.Models.Survey context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
