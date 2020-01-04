using System;
using Domain.Events;
using Newtonsoft.Json.Linq;

namespace Domain.RecipesDetails.Events.Recipes.Deleted
{
	public class RecipeDeletedEvent : IEvent
	{
		private RecipeDeletedEvent(Guid eventId, DateTime createdDate, Guid recipeId)
		{
			EventId = eventId;
			CreatedDate = createdDate;
			RecipeId = recipeId;
		}
		
		public Guid EventId { get; }
		public DateTime CreatedDate { get; }
		public Guid RecipeId { get; }
		
		public static RecipeDeletedEvent CreateFromMessage(Guid eventId, DateTime createdDate, string message)
		{
			var jsonMessage = JObject.Parse(message);
			var recipeId = (Guid)jsonMessage.SelectToken("recipeId");
			return new  RecipeDeletedEvent(eventId, createdDate, recipeId);
		}
	}
}