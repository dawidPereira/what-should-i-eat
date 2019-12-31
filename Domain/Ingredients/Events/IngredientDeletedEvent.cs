using System;
using Domain.Common.Mediators.Events;
using Newtonsoft.Json;

namespace Domain.Ingredients.Events
{
	public class IngredientDeletedEvent : Event
	{
		public IngredientDeletedEvent(Guid ingredientId) 
			: base(JsonConvert.SerializeObject(ingredientId), nameof(IngredientDeletedEvent ))
		{
		}
	}
}