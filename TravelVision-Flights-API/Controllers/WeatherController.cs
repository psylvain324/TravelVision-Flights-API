using System;
using Microsoft.AspNetCore.Mvc;
using TravelVision_Flights_API.Filters;
using TravelVision_Flights_API.Interfaces;

namespace TravelVision_Flights_API.Controllers
{
    [ApiKeyAuth]
    [Produces("application/json")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherService _weatherService;
        private readonly ICountryService _countryService;

        public WeatherController(IWeatherService weatherService, ICountryService countryService)
        {
            _weatherService = weatherService;
            _countryService = countryService;
        }
    }
}
