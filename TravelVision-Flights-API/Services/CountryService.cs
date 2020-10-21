using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelVision_Flights_API.Interfaces;
using TravelVision_Flights_API.Models;

namespace TravelVision_Flights_API.Services
{
    public class CountryService: ICountryService
    {
        private const string countriesUrl = "https://travelbriefing.org/countries.json";
        private const string countrySearchBase = "https://travelbriefing.org/Netherlands?format=json";
        private const string countryFlagsBase = "https://www.countryflags.io/:country_code/:style/:size.png";

        public CountryService()
        {

        }

        public Task<IEnumerable<Country>> GetAllCountries()
        {
            throw new NotImplementedException();
        }

    }
}
