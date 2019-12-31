namespace Domain.Events
{
	public interface IEventPublisher
	{
		void Publish(Event @event);
		void Rise();
	}
}