using System.Collections.Generic;
using System.Threading.Tasks;
using TravelVision_Flights_API.Models;

namespace TravelVision_Flights_API.Interfaces
{
    public interface ICountryService
    {
        Task<IEnumerable<Country>> GetAllCountries();
    }
}
