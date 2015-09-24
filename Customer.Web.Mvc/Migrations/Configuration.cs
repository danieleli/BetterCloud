using Customer.Web.Mvc.Models;
using System.Data.Entity.Migrations;

namespace Customer.Web.Mvc.Migrations
{    
    internal sealed class Configuration : DbMigrationsConfiguration<CustomerDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CustomerDb context)
        {

            context.Customers.AddOrUpdate(
                c => c.Id,
                new Models.Customer() { Id = 1, FirstName = "Robert", LastName = "Martin"},
                new Models.Customer() { Id = 2, FirstName = "Anders", LastName = "Heljlsberg"},
                new Models.Customer() { Id = 3, FirstName = "Jon", LastName = "Skeet"}
                );

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
