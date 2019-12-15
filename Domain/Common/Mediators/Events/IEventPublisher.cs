using System.Collections.Generic;

namespace Domain.Common.Mediators.Events
{
	public interface IEventPublisher
	{
		void Publish<TEvent>(TEvent @event) where TEvent : IEvent;
		void Rise(string queueName);
		void Rise(ICollection<string> queueNames);
	}
}