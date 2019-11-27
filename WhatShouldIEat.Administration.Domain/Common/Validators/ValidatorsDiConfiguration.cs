using Microsoft.Extensions.DependencyInjection;
using WhatShouldIEat.Administration.Domain.Ingredients.Commands.Create;

namespace WhatShouldIEat.Administration.Domain.Common.Validators
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