using System;
using Microsoft.AspNetCore.Mvc;
using TravelVision_Flights_API.Filters;

namespace TravelVision_Flights_API.Controllers
{
    [ApiKeyAuth]
    public class WeatherController : ControllerBase
    {
        public WeatherController()
        {
        }
    }
}
