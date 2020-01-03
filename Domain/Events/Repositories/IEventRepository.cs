using System;
using System.Collections.Generic;

namespace Domain.Events.Repositories
{
	public interface IEventRepository
	{
		void Add(EventMessage eventMessage);

		void RemoveById(Guid eventId);
		
		IEnumerable<IEvent> GetEventsToProcess();
	}
}