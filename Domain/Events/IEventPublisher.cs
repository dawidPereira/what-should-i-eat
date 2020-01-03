namespace Domain.Events
{
	public interface IEventPublisher
	{
		void Publish(EventMessage eventMessage);
		
		void Rise();
	}
}