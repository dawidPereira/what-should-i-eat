using System.Collections.Generic;
using Domain.Events;

namespace Infrastructure.Repositories.DataAccess.Events
{
	public interface IEventDataReader
	{
		IEnumerable<Event> GetEventsToProcess();
	}
}