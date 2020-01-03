using System;
using Domain.Events;
using Newtonsoft.Json;

namespace Domain.Recipes.Events.Deleted
{
	public class RecipeDeletedEventMessage : EventMessage
	{
		public RecipeDeletedEventMessage(Guid recipeId) 
			: base(JsonConvert.SerializeObject(recipeId), nameof(RecipeDeletedEventMessage))
		{
		}
	}
}