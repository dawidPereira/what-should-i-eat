using System.Collections.Generic;

namespace Domain.Events.Repositories
{
	public interface IEventRepository
	{
		void AddEvent(Event @event);
		
		IEnumerable<Event> GetEventsToProcess();

		void RemoveEvent(Event @event);
	}
}