namespace Domain.Common.Mediators.Events
{
	public interface IEventHandler<in TEvent> where TEvent : IEvent
	{
		void Handle(TEvent @event);
	}
}