using System;

namespace Domain.RecipesDetails.Ingredients.Queries.GetIngredientsBasicInfos
{
	public class IngredientBasicInfo
	{
		public IngredientBasicInfo(Guid id, string name)
		{
			Id = id;
			Name = name;
		}
		
		public Guid Id { get; private set; }
		public string Name { get; private set; }
	}
}