using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TravelVision_Flights_API.Interfaces;
using TravelVision_Flights_API.Models;

namespace TravelVision_Flights_API.Services
{
    public class CountryService: ICountryService
    {
        private const string countriesUrl = "https://travelbriefing.org/countries.json";
        private const string countrySearchBase = "https://travelbriefing.org/Netherlands?format=json";
        private const string countryFlagsBase = "https://www.countryflags.io/:country_code/:style/:size.png";
        private readonly HttpClient _client;

        public CountryService(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<Country>> GetAllCountries()
        {
            HttpResponseMessage httpResponse = await _client.GetAsync(countriesUrl);

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Unable to retrieve Countries!");
            }

            string content = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
            IEnumerable<Country> countries = JsonConvert.DeserializeObject<IEnumerable<Country>>(content);

            return countries;
        }

    }
}
