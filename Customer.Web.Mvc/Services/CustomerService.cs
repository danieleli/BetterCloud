using System;
using System.Diagnostics;
using System.Linq;
using Customer.Web.Mvc.Services.Geocode;

namespace Customer.Web.Mvc.Services
{
    using Customer = Models.Customer;

    public interface ICustomerService: IDisposable
    {
        IQueryable<Customer> Customers { get; } 
        void Save(Customer c);
        void Delete(int id);
    }
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerDao _dao;
        private readonly IGeocodeAdapter _geocoder;
        
        public CustomerService(ICustomerDao dao, IGeocodeAdapter geocoder)
        {
            _dao = dao;
            _geocoder = geocoder;
        }

        // Read
        public IQueryable<Customer> Customers => _dao.Customers;

        // Delete
        public void Delete(int id)
        {
            _dao.Delete(id);
        }

        // Create / Update
        public void Save(Customer c)
        {
            if (c.Id < 1)
            {
                GeocodeAddress(c);
                _dao.Create(c);
            }
            else
            {
                if (IsNewAddress(c))
                {
                    GeocodeAddress(c);
                }

                _dao.Update(c);
            }
        }

        private bool IsNewAddress(Customer customer)
        {
            var previousState = _dao.Customers.Single(c => c.Id == customer.Id);

            return previousState.Address != customer.Address;
        }

        private void GeocodeAddress(Customer c)
        {
            c.Latitude = null;
            c.Longitude = null;

            if (string.IsNullOrWhiteSpace(c.Address))
            {
                return;
            }

            try
            {
                var coordinates = _geocoder.GeocodeAddress(c.Address);
                c.Latitude = coordinates.Latitude;
                c.Longitude = coordinates.Longitude;
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error while geocoding addresss {0} /nError: {1}", c.Address, e.Message);
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dao.Dispose();
                // Dispose any other disposible resources here.
            }
        }
    }
}