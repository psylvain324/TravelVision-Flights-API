using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelVision_Flights_API.ViewModels;

namespace TravelVision_Flights_API.Interfaces
{
    public interface IWeatherService
    {
        Task<CurrentWeatherViewModel> GetCurrentWeather(string search);
        Task<ForecastViewModel> GetWeatherForecast(string search, int days);
        Task<IEnumerable<WeatherSearchViewModel>> GetCitySearch(string search);
        Task<AstronomyViewModel> GetAstronomy(string search, DateTime date);
        Task<TimeZoneViewModel> GetTimeZone(string search);
        Task<SportsViewModel> GetSportsStadiums(string search);
    }
}
