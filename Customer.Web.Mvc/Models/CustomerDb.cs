using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Customer.Web.Mvc.Models
{


    public interface ICustomerDb : IDisposable
    {
        IDbSet<Customer> Customers { get; set; }

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();

    }
    public class CustomerDb : DbContext, ICustomerDb
    {
        public CustomerDb():base("CustomerDb") { }

        public IDbSet<Customer> Customers { get; set; }
    }
}