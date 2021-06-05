using System.Threading.Tasks;

namespace Domain.Events
{
	public interface IEventPublisher
	{
		Task Publish(EventMessage eventMessage);

		void Rise();
	}
}
