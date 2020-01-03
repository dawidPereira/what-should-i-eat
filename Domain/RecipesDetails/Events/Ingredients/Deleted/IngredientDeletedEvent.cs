using System;
using Domain.Events;
using Newtonsoft.Json.Linq;

namespace Domain.RecipesDetails.Events.Ingredients.Deleted
{
	public class IngredientDeletedEvent : IEvent
	{
		private IngredientDeletedEvent(Guid eventId, DateTime createdDate, Guid ingredientId)
		{
			EventId = eventId;
			CreatedDate = createdDate;
			IngredientId = ingredientId;
		}
		
		public Guid EventId { get; }
		public DateTime CreatedDate { get; }
		public Guid IngredientId { get; }
		
		public static IngredientDeletedEvent CreateFromMessage(Guid eventId, DateTime createdDate, string message)
		{
			var jsonMessage = JObject.Parse(message);
			var ingredientId = (Guid)jsonMessage.SelectToken("ingredientId");
			return new  IngredientDeletedEvent(eventId, createdDate, ingredientId);
		}
	}
}