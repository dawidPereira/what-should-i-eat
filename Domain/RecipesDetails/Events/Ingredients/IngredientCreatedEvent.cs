using System;
using Domain.Events;
using Newtonsoft.Json.Linq;

namespace Domain.RecipesDetails.Events.Ingredients
{
	public class IngredientCreatedEvent : IEvent
	{
		public IngredientCreatedEvent(Guid eventId, DateTime createdDate, Guid ingredientId)
		{
			EventId = eventId;
			CreatedDate = createdDate;
			IngredientId = ingredientId;
		}
		public Guid EventId { get; }
		public DateTime CreatedDate { get; } 
		public Guid IngredientId { get; }

		public static IngredientCreatedEvent CreateFromMessage(Guid eventId, DateTime createdDate, string message)
		{
			var jsonMessage = JObject.Parse(message);
			var ingredientId = (Guid)jsonMessage.SelectToken("ingredientId");
			return new  IngredientCreatedEvent(eventId, createdDate, ingredientId);
		}
		
	}
}