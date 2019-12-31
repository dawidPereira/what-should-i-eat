using Domain.Events;

namespace Infrastructure.Repositories.DataAccess.Events
{
	public interface IEventDataWriter
	{
		void Add(Event @event);

		void Remove(Event @event);
	}
}