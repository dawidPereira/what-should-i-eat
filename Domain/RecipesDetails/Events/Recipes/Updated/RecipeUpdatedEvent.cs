using System;
using Domain.Events;
using Newtonsoft.Json.Linq;

namespace Domain.RecipesDetails.Events.Recipes.Updated
{
	public class RecipeUpdatedEvent : IEvent
	{
		private RecipeUpdatedEvent(Guid eventId, DateTime createdDate, Guid recipeId)
		{
			EventId = eventId;
			CreatedDate = createdDate;
			RecipeId = recipeId;
		}
		
		public Guid EventId { get; }
		public DateTime CreatedDate { get; }
		public Guid RecipeId { get; }
		
		public static RecipeUpdatedEvent CreateFromMessage(Guid eventId, DateTime createdDate, string message)
		{
			var jsonMessage = JObject.Parse(message);
			var recipeId = (Guid)jsonMessage.SelectToken("recipeId");
			return new  RecipeUpdatedEvent(eventId, createdDate, recipeId);
		}
	}
}