using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TravelVision_Flights_API.Models;

namespace TravelVision_Flights_API.Controllers
{
    public class FlightsController
    {
        private readonly HttpClient _client;

        public FlightsController(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<Airport>> GetAllAirports()
        {
            HttpResponseMessage httpResponse = await _client.GetAsync("");

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Unable to retrieve Airports!");
            }

            string content = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
            List<Airport> airports = JsonConvert.DeserializeObject<List<Airport>>(content);

            return airports;
        }
    }
}
