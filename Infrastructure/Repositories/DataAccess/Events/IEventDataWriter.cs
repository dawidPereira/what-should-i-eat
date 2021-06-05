using System.Threading.Tasks;
using Infrastructure.Entities.Events;

namespace Infrastructure.Repositories.DataAccess.Events
{
	public interface IEventDataWriter
	{
		Task Add(OutboxEvent outboxEvent);

		void Remove(OutboxEvent eventId);
	}
}
