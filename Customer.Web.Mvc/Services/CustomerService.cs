using System;
using System.Data.Entity;
using System.Linq;
using Customer.Web.Mvc.Models;


namespace Customer.Web.Mvc.Services
{
    using Customer = Models.Customer;

    public interface ICustomerService : IDisposable
    {
        IQueryable<Customer> GetAll();
        Customer GetById(int id);
        void Create(Customer customer);
        void Update(Customer customer);
        void Delete(int id);
    }


    public class CustomerService : ICustomerService
    {
        private readonly ICustomerDb _db;

        public CustomerService()
        {
            _db = new CustomerDb();
        }

        public IQueryable<Customer> GetAll()
        {
            return _db.Customers;
        }

        public Customer GetById(int id)
        {
            return _db.Customers.Find(id);
        }

        public void Create(Customer customer)
        {
            _db.Customers.Add(customer);
            _db.SaveChanges();
        }

        public void Update(Customer customer)
        {
            _db.Entry(customer).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var customer = _db.Customers.Find(id);
            _db.Customers.Remove(customer);
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