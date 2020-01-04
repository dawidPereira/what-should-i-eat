using Domain.Events;
using Domain.RecipesDetails.Events.Ingredients.Updated;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Events.EventPublishers
{
	public static class EventPublisherDiConfiguration
	{
		public static IServiceCollection AddEvents(this IServiceCollection services)
		{
			services.AddScoped<IEventPublisher, EventPublisher>();

			services.Scan(scan =>
				scan
					.FromAssemblyOf<IngredientUpdatedEvent>()
					.AddClasses(classes => classes.AssignableTo(typeof(IEventHandler<>)))
					.AsImplementedInterfaces()
					.WithTransientLifetime());

			return services;
		}
	}
}