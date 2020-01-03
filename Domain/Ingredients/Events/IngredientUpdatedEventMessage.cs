using System;
using Domain.Events;
using Newtonsoft.Json.Linq;

namespace Domain.Ingredients.Events
{
	public class IngredientUpdatedEventMessage : EventMessage
	{
		private new const string EventType = "IngredientUpdatedEvent";
		
		private IngredientUpdatedEventMessage(string message) 
			: base(message, EventType)
		{
		}

		public static IngredientUpdatedEventMessage Create(Guid ingredientId) => 
			new IngredientUpdatedEventMessage(BuildMessage(ingredientId));

		private static string BuildMessage(Guid ingredientId)
		{
			dynamic json = new JObject();
			json.ingredientId = ingredientId;
			return json.ToString();
		}
	}
}