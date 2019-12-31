using System;
using Domain.Common.Mediators.Events;
using Newtonsoft.Json;

namespace Domain.Recipes.Events.Updated
{
	public class RecipeUpdatedEvent : Event
	{
		public RecipeUpdatedEvent(Guid recipeId) 
			: base(JsonConvert.SerializeObject(recipeId), nameof(RecipeUpdatedEvent))
		{
		}
	}
}