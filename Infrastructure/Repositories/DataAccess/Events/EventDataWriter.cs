using Domain.Events;
using Infrastructure.DbContexts;

namespace Infrastructure.Repositories.DataAccess.Events
{
	public class EventDataWriter : IEventDataWriter
	{
		private readonly AdministrationDbContext _context;

		public EventDataWriter(AdministrationDbContext context)
		{
			_context = context;
		}

		public void Add(Event @event) => _context.Events.Add(@event);

		public void Remove(Event @event) => _context.Remove(@event);
	}
}