using System.Collections.Generic;

namespace TravelVision_Flights_API.Interfaces
{
    public interface IRepository<T>
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        bool Add(T item);
        bool Delete(int id);
        bool Edit(T item);
        bool Exists(int id);
    }
}
