using System;
using Domain.Events;
using Newtonsoft.Json;

namespace Domain.Recipes.Events.Updated
{
	public class RecipeUpdatedEventMessage : EventMessage
	{
		public RecipeUpdatedEventMessage(Guid recipeId) 
			: base(JsonConvert.SerializeObject(recipeId), nameof(RecipeUpdatedEventMessage))
		{
		}
	}
}