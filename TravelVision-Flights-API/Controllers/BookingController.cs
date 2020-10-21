using System;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;

namespace TravelVision_Flights_API.Controllers
{
    [Produces("application/json")]
    [ApiController]
    public class BookingController: Controller
    {
        private readonly HttpClient _client;

        public BookingController(HttpClient client)
        {
            _client = client;
        }
    }
}
