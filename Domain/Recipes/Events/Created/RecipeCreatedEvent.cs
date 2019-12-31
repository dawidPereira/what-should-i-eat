using System;
using Domain.Events;
using Newtonsoft.Json;

namespace Domain.Recipes.Events.Created
{
	public class RecipeCreatedEvent : Event
	{
		public RecipeCreatedEvent(Guid recipeId) 
			: base(JsonConvert.SerializeObject(recipeId), nameof(RecipeCreatedEvent))
		{
		}
	}
}