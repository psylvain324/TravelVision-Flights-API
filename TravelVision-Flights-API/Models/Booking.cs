using System;
namespace TravelVision_Flights_API.Models
{
    public class Booking
    {
        public int Id { get; set; }

        public Airport From { get; set; }

        public Airport To { get; set; }

        public DateTime Departure { get; set; }

        public DateTime Arrival { get; set; }

        public string ConfirmationCode { get; set; }
    }
}
