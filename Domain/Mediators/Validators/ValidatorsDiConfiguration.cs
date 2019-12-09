using Domain.Ingredients.Commands.Create;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.Mediators.Validators
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