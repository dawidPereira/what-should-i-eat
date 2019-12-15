using Domain.RecipesDetails.Ingredients.Commands.Create;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.Common.Mediators.Validators
{
	public static class ValidatorsDiConfiguration
	{
		public static IServiceCollection AddDomainValidators(this IServiceCollection services)
		{
			services.Scan(scan =>
				scan
					.FromAssemblyOf<CreateIngredientCommand>()
					.AddClasses(classes => classes.AssignableTo(typeof(ICommandValidator<>)))
					.AsImplementedInterfaces()
					.WithTransientLifetime());

			return services;
		}
	}
}