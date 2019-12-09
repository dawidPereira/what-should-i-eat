using Api.Validators.IngredientValidators;
using Api.Validators.RecipeValidators;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Validators
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