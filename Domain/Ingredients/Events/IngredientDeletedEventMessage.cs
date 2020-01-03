using System;
using Domain.Events;
using Newtonsoft.Json.Linq;

namespace Domain.Ingredients.Events
{
	public class IngredientDeletedEventMessage : EventMessage
	{
		private new const string EventType = "IngredientDeletedEvent";

		private IngredientDeletedEventMessage(string message) 
			: base(message, EventType)
		{
		}
		
		public static IngredientDeletedEventMessage Create(Guid ingredientId) => 
			new IngredientDeletedEventMessage(BuildMessage(ingredientId));

		private static string BuildMessage(Guid ingredientId)
		{
			dynamic json = new JObject();
			json.ingredientId = ingredientId;
			return json.ToString();
		}
	}
}