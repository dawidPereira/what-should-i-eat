namespace Domain.Common.Mediators.Events
{
	public interface IEventPublisher
	{
		void Publish(Event @event);
		void Rise();
	}
}