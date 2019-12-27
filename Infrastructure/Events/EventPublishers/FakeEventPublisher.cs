using System.Collections.Generic;
using Domain.Common.Mediators.Events;

namespace Infrastructure.Events.EventPublishers
{
	public class FakeEventPublisher : IEventPublisher
	{
		public void Publish<TEvent>(TEvent @event) where TEvent : IEvent<TEvent>
		{
		}

		public void Rise(string queueName)
		{
		}

		public void Rise(ICollection<string> queueNames)
		{
		}
	}
}