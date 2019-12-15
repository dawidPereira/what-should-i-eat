using System;

namespace Domain.RecipesDetails.Recipes.Queries.GetBasicInfos
{
	public class RecipeBasicInfo
	{
		public RecipeBasicInfo(Guid id, string name)
		{
			Id = id;
			Name = name;
		}
		public Guid Id { get; private set; }
		public string Name { get; private set; }
	}
}