using System;
using Domain.Common.Mediators.Queries;

namespace Domain.Recipes.Queries.GetById
{
	public class GetRecipeQuery : IQuery<RecipeDto>
	{
		public Guid Id { get; set; }
	}
}