using System;

namespace Customer.Web.Mvc.Services.Geocode
{
    public interface IGeocodeAdapter
    {
        GeoCoordinate GeocodeAddress(string address);
    }

    public class GeocodeAdapter : IGeocodeAdapter
    {
        private readonly IGeocodeConfig _config;

        public GeocodeAdapter(IGeocodeConfig config)
        {
            _config = config;
            InitializeImplementation();
        }

        private void InitializeImplementation()
        {
            // Instantiate and initialize here.
        }

        public GeoCoordinate GeocodeAddress(string address)
        {
            // _implementation.GeocodeMe(address);
            // throw exception if geocode fails.
            throw new NotImplementedException();
        }
    }
}