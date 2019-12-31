using Domain.Events;
using Domain.Recipes.Events.Created;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Events.EventPublishers
{
	public static class EventPublisherDiConfiguration
	{
		public static IServiceCollection AddEvents(this IServiceCollection services)
		{
			services.AddSingleton<IEventPublisher, EventPublisher>();

			services.Scan(scan =>
				scan
					.FromAssemblyOf<RecipeCreatedEvent>()
					.AddClasses(classes => classes.AssignableTo(typeof(IEventHandler<>)))
					.AsImplementedInterfaces()
					.WithTransientLifetime());

			return services;
		}
	}
}