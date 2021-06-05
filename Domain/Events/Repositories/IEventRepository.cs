using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Events.Repositories
{
	public interface IEventRepository
	{
		Task Add(EventMessage eventMessage);

		void RemoveById(Guid eventId);

		IEnumerable<IEvent> GetEventsToProcess();
	}
}
