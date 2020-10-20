using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using TravelVision_Flights_API.Data;
using TravelVision_Flights_API.Interfaces;
using TravelVision_Flights_API.Models;

namespace TravelVision_Flights_API.Repositories
{
	public class StoryRepository : IRepository<Booking>
	{
		private readonly DatabaseContext _context;
		private readonly ILogger<StoryRepository> _logger;

		public StoryRepository(DatabaseContext context, ILogger<StoryRepository> logger)
		{
			_context = context;
			_logger = logger;
		}

		public StoryRepository(DatabaseContext context)
		{
			_context = context;
		}

		public bool Add(Booking booking)
		{
			try
			{
				_context.Bookings.Add(booking);
				_context.SaveChanges();
				return true;
			}
			catch
			{
				_logger.LogError("Failed to add Booking!");
				throw;
			}
		}

		public bool Delete(int id)
		{
			try
			{
				Booking booking = GetById(id);
				if (booking != null)
				{
					_context.Bookings.Remove(booking);
					_context.SaveChanges();
					return true;
				}
				return false;
			}
			catch
			{
				_logger.LogError("Unable to delete Booking!");
				throw;
			}
		}

		public bool Edit(Booking booking)
		{
			try
			{
				_context.Bookings.Update(booking);
				_context.SaveChanges();
				return true;
			}
			catch
			{
				_logger.LogError("Unable to save Booking!");
				throw;
			}
		}

		public Booking GetById(int id)
		{
			if (!_context.Bookings.Any(x => x.Id == id))
			{
				return null;
			}
			return _context.Bookings.First(x => x.Id == id);
		}

		public IEnumerable<Booking> GetAll()
		{
			return _context.Bookings;
		}

		public bool Exists(int id)
		{
			return _context.Bookings.SingleOrDefault(e => e.Id == id) != null;
		}

	}
}
