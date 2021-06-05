using System.Threading.Tasks;

namespace Domain.Events
{
	public interface IEventHandler<in TEvent> where TEvent : IEvent
	{
		Task Handle(TEvent @event);
	}
}
