using Infrastructure.DbContexts;
using Infrastructure.Entities.Events;

namespace Infrastructure.Repositories.DataAccess.Events
{
	public class EventDataWriter : IEventDataWriter
	{
		private readonly AdministrationDbContext _context;

		public EventDataWriter(AdministrationDbContext context)
		{
			_context = context;
		}

		public void Add(OutboxEvent outboxEvent) => _context.Events.Add(outboxEvent);

		public void Remove(OutboxEvent outboxEvent)
		{
			_context.Remove(outboxEvent);
			_context.SaveChanges();
		}
	}
}