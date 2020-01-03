using System;
using Domain.Events;
using Newtonsoft.Json;

namespace Domain.Ingredients.Events
{
	public class IngredientDeletedEventMessage : EventMessage
	{
		public IngredientDeletedEventMessage(Guid ingredientId) 
			: base(JsonConvert.SerializeObject(ingredientId), typeof(IngredientDeletedEventMessage).FullName)
		{
		}
	}
}