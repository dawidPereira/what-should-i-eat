using System;
using System.Collections.Generic;
using Infrastructure.Entities.Events;

namespace Infrastructure.Repositories.DataAccess.Events
{
	public interface IEventDataReader
	{
		IEnumerable<OutboxEvent> GetEventsToProcess();

		OutboxEvent GetEventById(Guid eventId);
	}
}