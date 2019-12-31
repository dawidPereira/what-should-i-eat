using System.Collections.Generic;
using Domain.Events;
using Infrastructure.DbContexts;

namespace Infrastructure.Repositories.DataAccess.Events
{
	public class EventDataReader : IEventDataReader
	{
		private readonly AdministrationDbContext _context;

		public EventDataReader(AdministrationDbContext context)
		{
			_context = context;
		}

		public IEnumerable<Event> GetEventsToProcess() => _context.Events;
	}
}