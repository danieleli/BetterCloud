using System.Data.Entity;

namespace Customer.Web.Mvc.Models
{
    public class CustomerDb : DbContext
    {
        public CustomerDb():base("CustomerDb") { }

        public DbSet<Customer> Customers { get; set; }
    }
}