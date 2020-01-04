using System;
using Domain.Events;
using Newtonsoft.Json.Linq;

namespace Domain.RecipesDetails.Events.Recipes.Created
{
	public class RecipeCreatedEvent: IEvent
	{
		private RecipeCreatedEvent(Guid eventId, DateTime createdDate, Guid recipeId)
		{
			EventId = eventId;
			CreatedDate = createdDate;
			RecipeId = recipeId;
		}
		
		public Guid EventId { get; }
		public DateTime CreatedDate { get; }
		public Guid RecipeId { get; }
		
		public static RecipeCreatedEvent CreateFromMessage(Guid eventId, DateTime createdDate, string message)
		{
			var jsonMessage = JObject.Parse(message);
			var recipeId = (Guid)jsonMessage.SelectToken("recipeId");
			return new  RecipeCreatedEvent(eventId, createdDate, recipeId);
		}
	}
}