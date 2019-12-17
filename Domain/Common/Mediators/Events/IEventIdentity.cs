using System;
using Domain.Common.ValueObjects;

namespace Domain.Common.Mediators.Events
{
	public interface IEventIdentity 
	{
		Identity<Guid> Id { get; }
		string QueueName { get; }
	}
}