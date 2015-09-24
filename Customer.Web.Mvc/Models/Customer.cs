using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Customer.Web.Mvc.Models
{
    public class CustomerDb : DbContext
    {
        public CustomerDb():base("CustomerDb") { }

        public DbSet<Customer> Customers { get; set; }
    }


    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        [Required, MinLength(3)]
        public string LastName { get; set; }
        
        [Timestamp]
        public byte[] Timestamp { get; set; }
    }
}