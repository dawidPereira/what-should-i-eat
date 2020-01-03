using Domain.Events;
using Infrastructure.Entities.Events;

namespace Infrastructure.Mappers.Events
{
	public interface IEventMapper
	{
		IEvent FromOutboxEvent(OutboxEvent @event);
	}
}