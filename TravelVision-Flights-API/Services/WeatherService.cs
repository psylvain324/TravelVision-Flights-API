using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TravelVision_Flights_API.Interfaces;
using TravelVision_Flights_API.ViewModels;

namespace TravelVision_Flights_API.Services
{
    public class WeatherService: IWeatherService
    {
        private const string baseApiUrl = "http://api.weatherapi.com/v1";
        private readonly HttpClient _client;

        public WeatherService(HttpClient client)
        {
            _client = client;
        }

        public Task<AstronomyViewModel> GetAstronomy(string search, DateTime date)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<WeatherSearchViewModel>> GetCitySearch(string search)
        {
            throw new NotImplementedException();
        }

        public Task<CurrentWeatherViewModel> GetCurrentWeather(string search)
        {
            throw new NotImplementedException();
        }

        public Task<SportsViewModel> GetSportsStadiums(string search)
        {
            throw new NotImplementedException();
        }

        public Task<TimeZoneViewModel> GetTimeZone(string search)
        {
            throw new NotImplementedException();
        }

        public Task<ForecastViewModel> GetWeatherForecast(string search, int days)
        {
            throw new NotImplementedException();
        }
    }
}
