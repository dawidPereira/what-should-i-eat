using System.Threading.Tasks;
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

		public async Task Add(OutboxEvent outboxEvent) => await _context.Events.AddAsync(outboxEvent);

		public void Remove(OutboxEvent outboxEvent)
		{
			_context.Remove(outboxEvent);
			_context.SaveChanges();
		}
	}
}
