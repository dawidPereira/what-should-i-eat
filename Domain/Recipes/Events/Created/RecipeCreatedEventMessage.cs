using System;
using Domain.Events;
using Newtonsoft.Json.Linq;

namespace Domain.Recipes.Events.Created
{
	public class RecipeCreatedEventMessage : EventMessage
	{
		private new const string EventType = "RecipeCreatedEvent";

		private RecipeCreatedEventMessage(string message) 
			: base(message, EventType)
		{
		}

		public static RecipeCreatedEventMessage Create(Guid recipeId) => 
			new RecipeCreatedEventMessage(BuildMessage(recipeId));

		private static string BuildMessage(Guid recipeId)
		{
			dynamic json = new JObject();
			json.recipeId = recipeId;
			return json.ToString();
		}
	}
}