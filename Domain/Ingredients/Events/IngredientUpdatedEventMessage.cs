using System;
using Domain.Events;
using Newtonsoft.Json;

namespace Domain.Ingredients.Events
{
	public class IngredientUpdatedEventMessage : EventMessage
	{
		public IngredientUpdatedEventMessage(Guid ingredientId) 
			: base(JsonConvert.SerializeObject(ingredientId), typeof(IngredientUpdatedEventMessage).FullName)
		{
		}
	}
}