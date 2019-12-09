using System;
using Domain.Mediators.Query;

namespace Domain.Recipes.Queries.GetRecipe
{
	public class GetRecipeQuery : IQuery<RecipeDto>
	{
		public Guid Id { get; set; }
	}
}