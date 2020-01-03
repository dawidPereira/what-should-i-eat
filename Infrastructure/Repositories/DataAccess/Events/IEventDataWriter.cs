using Infrastructure.Entities.Events;

namespace Infrastructure.Repositories.DataAccess.Events
{
	public interface IEventDataWriter
	{
		void Add(OutboxEvent outboxEvent);

		void Remove(OutboxEvent eventId);
	}
}