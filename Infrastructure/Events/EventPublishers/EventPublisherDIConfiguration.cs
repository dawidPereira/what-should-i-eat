using Domain.Mediators.Events;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Events.EventPublishers
{
	public static class EventPublisherDIConfiguration
	{
		public static IServiceCollection AddEventPublisher(this IServiceCollection services)
		{
			services.AddScoped<IEventPublisher, EventPublisher>();

			services.Scan(scan =>
				scan
					//TODO: Add event class
					.FromAssemblyOf<IEventHandler<IEvent>>()
					.AddClasses(classes => classes.AssignableTo(typeof(IEventHandler<>)))
					.AsImplementedInterfaces()
					.WithTransientLifetime());

			return services;
		}
	}
}