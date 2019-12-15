using System;

namespace Domain.Common.Mediators.Events
{
	public abstract class Event : IEvent
	{
		protected Event(string queueName)
		{
			Id = Guid.NewGuid();
			QueueName = queueName;
		}
		public Guid Id { get; }
		public string QueueName { get; }
	}
}