namespace Domain.Events
{
	public interface IEventHandler<in TEvent> where TEvent : IEvent<TEvent>
	{
		void Handle(TEvent @event);
	}
}