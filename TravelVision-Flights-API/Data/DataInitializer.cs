using System.Linq;

namespace TravelVision_Flights_API.Data
{
    public static class DataInitializer
    {
        public static void Initialize(DatabaseContext databaseContext)
        {
            databaseContext.Database.EnsureCreated();
            if (databaseContext.Airports.Any())
            {
                return;
            }
     
            databaseContext.SaveChanges();
        }

        public static void Seed(this DatabaseContext dbContext)
        {

        }
    }
}
