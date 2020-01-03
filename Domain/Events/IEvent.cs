using System;

namespace Domain.Events
{
	public interface IEvent
	{
		Guid EventId { get; }

		DateTime CreatedDate { get; }
	}
}