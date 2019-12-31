using System;
using Domain.Common.Mediators.Events;
using Newtonsoft.Json;

namespace Domain.Ingredients.Events
{
	public class IngredientCreatedEvent : Event
	{
		public IngredientCreatedEvent(Guid ingredientId) 
			: base(JsonConvert.SerializeObject(ingredientId), nameof(IngredientCreatedEvent))
		{
		}
	}
}