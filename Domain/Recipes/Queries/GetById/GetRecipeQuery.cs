using System;
using Domain.Common.Mediators.Queries;

namespace Domain.Recipes.Queries.GetById
{
	public class GetRecipeQuery : IQuery<RecipeDto>
	{
		public GetRecipeQuery(Guid id)
		{
			Id = id;
		}
		
		public Guid Id { get; set; }
	}
}