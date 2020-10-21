using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelVision_Flights_API.Filters;
using TravelVision_Flights_API.Interfaces;
using TravelVision_Flights_API.ViewModels;

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

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [Route("/Astronomy/{search}/{date}")]
        public async Task<AstronomyViewModel> GetAstronomy(string search, DateTime date)
        {
            return await _weatherService.GetAstronomy(search, date);
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [Route("/City/{search}")]
        public async Task<IEnumerable<WeatherSearchViewModel>> GetCitySearch(string search)
        {
            return await _weatherService.GetCitySearch(search);
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [Route("/Current/{search}")]
        public async Task<CurrentWeatherViewModel> GetCurrentWeather(string search)
        {
            return await _weatherService.GetCurrentWeather(search);
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [Route("/Sports/{search}")]
        public async Task<SportsViewModel> GetSportsStadiums(string search)
        {
            return await _weatherService.GetSportsStadiums(search);
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [Route("/Timezone/{search}")]
        public async Task<TimeZoneViewModel> GetTimeZone(string search)
        {
            return await _weatherService.GetTimeZone(search);
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [Route("/Forecast/{search}/{days}")]
        public async Task<ForecastViewModel> GetWeatherForecast(string search, int days)
        {
            return await _weatherService.GetWeatherForecast(search, days);
        }
    }
}
