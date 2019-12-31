using System;
using Domain.Common.Mediators.Events;
using Newtonsoft.Json;

namespace Domain.Recipes.Events.Deleted
{
	public class RecipeDeletedEvent : Event
	{
		public RecipeDeletedEvent(Guid recipeId) 
			: base(JsonConvert.SerializeObject(recipeId), nameof(RecipeDeletedEvent))
		{
		}
	}
}