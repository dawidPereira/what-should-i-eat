using Domain.Common.Mediators.Events;
using Domain.RecipesDetails.Recipes.Events.Created;
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
					.FromAssemblyOf<RecipeCreatedEvent>()
					.AddClasses(classes => classes.AssignableTo(typeof(IEventHandler<>)))
					.AsImplementedInterfaces()
					.WithTransientLifetime());

			return services;
		}
	}
}