using Microsoft.Extensions.DependencyInjection;
using WhatShouldIEat.Administration.Api.Validators.IngredientValidators;
using WhatShouldIEat.Administration.Api.Validators.RecipeValidators;

namespace WhatShouldIEat.Administration.Api.Validators
{
	public static class RequestValidatorsDiConfiguration
	{
		public static IServiceCollection AddRequestValidators(this IServiceCollection services)
		{
			services.AddTransient<IRecipeValidatorsFacade , RecipeValidatorsFacade>();
			services.AddTransient<IIngredientValidatorsFacade, IngredientValidatorsFacade>();
			
			return services;
		}
	}
}