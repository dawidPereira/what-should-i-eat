using System;

namespace Domain.Events
{
	public interface IEventMessage : IEquatable<IEventMessage>
	{
		Guid Id { get; }
		
		string EventType { get; }
		
		string Message { get; }
		
		DateTime CreatedDate { get; }
	}
}