using Domain.Common.Mediators;
using Domain.Common.Mediators.Commands;
using Domain.Common.Mediators.Queries;
using Domain.RecipesDetails.Ingredients.Commands.Create;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Mediator
{
	public static class MediatorDiConfiguration
	{
		public static IServiceCollection AddMediator(this IServiceCollection services)
		{
			services.AddScoped<IMediator, Mediator>();

			services.Scan(scan =>
				scan
					.FromAssemblyOf<CreateIngredientCommand>()
					.AddClasses(classes => classes.AssignableTo(typeof(ICommandHandler<>)))
					.AsImplementedInterfaces()
					.WithTransientLifetime()
					.AddClasses(classes => classes.AssignableTo(typeof(IQueryHandler<,>)))
					.AsImplementedInterfaces()
					.WithTransientLifetime());

			return services;
		}
	}
}