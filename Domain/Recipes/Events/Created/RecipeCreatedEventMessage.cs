using System;
using Domain.Events;
using Newtonsoft.Json;

namespace Domain.Recipes.Events.Created
{
	public class RecipeCreatedEventMessage : EventMessage
	{
		public RecipeCreatedEventMessage(Guid recipeId) 
			: base(JsonConvert.SerializeObject(recipeId), nameof(RecipeCreatedEventMessage))
		{
		}
	}
}