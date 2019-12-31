using System;
using Domain.Common.Mediators.Events;
using Newtonsoft.Json;

namespace Domain.Ingredients.Events
{
	public class IngredientUpdatedEvent : Event
	{
		public IngredientUpdatedEvent(Guid ingredientId) 
			: base(JsonConvert.SerializeObject(ingredientId), nameof(IngredientUpdatedEvent ))
		{
		}
	}
}