using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructure.DbContexts;
using Infrastructure.Entities.Events;

namespace Infrastructure.Repositories.DataAccess.Events
{
	public class EventDataReader : IEventDataReader
	{
		private readonly AdministrationDbContext _context;

		public EventDataReader(AdministrationDbContext context)
		{
			_context = context;
		}

		public IEnumerable<OutboxEvent> GetEventsToProcess() => _context.Events;

		public OutboxEvent GetEventById(Guid eventId) => _context.Events.FirstOrDefault(x => x.Id == eventId);
	}
}