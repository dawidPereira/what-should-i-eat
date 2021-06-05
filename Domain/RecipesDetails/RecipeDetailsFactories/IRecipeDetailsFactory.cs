using System;
using System.Threading.Tasks;
using Domain.RecipesDetails.Entities;

namespace Domain.RecipesDetails.RecipeDetailsFactories
{
	public interface IRecipeDetailsFactory
	{
		Task<RecipeDetails> Create(Guid recipeId);
	}
}
