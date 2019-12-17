using System;

namespace Domain.Common.Mediators.Events
{
	public interface IEventIdentity 
	{
		Guid Id { get; }
		string QueueName { get; }
	}
}