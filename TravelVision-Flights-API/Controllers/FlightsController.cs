using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TravelVision_Flights_API.Models;

namespace TravelVision_Flights_API.Controllers
{
    [Produces("application/json")]
    [ApiController]
    public class FlightsController: Controller
    {
        private readonly HttpClient _client;

        public FlightsController(HttpClient client)
        {
            _client = client;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [Route("/Airports")]
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

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [Route("/Airport/{location}")]
        public async Task<Airport> GetAirportByLocation(string location)
        {
            HttpResponseMessage httpResponse = await _client.GetAsync("" + location);

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Unable to retrieve Airport!");
            }

            string content = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
            Airport airport = JsonConvert.DeserializeObject<Airport>(content);

            return airport;
        }

        public async Task<IEnumerable<Flight>> GetFlightAvailability()
        {
            List<Flight> flight = new List<Flight>();
            HttpResponseMessage httpResponse = await _client.GetAsync("");

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Unable to retrieve Flights!");
            }

            string content = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
            List<Journey> journies = JsonConvert.DeserializeObject<List<Journey>>(content);


            return flight;
        }
    }
}
