using System;
using System.Data.Entity;
using System.Linq;
using Customer.Web.Mvc.Models;

namespace Customer.Web.Mvc.Services
{
    using Customer = Models.Customer;

    public interface ICustomerDao : IDisposable
    {
        IQueryable<Customer> Customers { get; }
        void Create(Customer c);
        void Update(Customer c);
        void Delete(int id);
    }


    public class CustomerDao : ICustomerDao
    {
        private readonly ICustomerDb _db;

        public CustomerDao()
        {
            _db = new CustomerDb();
        }
        

        public IQueryable<Customer> Customers => _db.Customers;

        public void Create(Customer c)
        {
            _db.Customers.Add(c);
            _db.SaveChanges();
        }
        
        public void Update(Customer c)
        {
            _db.Entry(c).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var c = _db.Customers.Find(id);
            _db.Customers.Remove(c);
            _db.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
        }
    }
}