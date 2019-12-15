using System;
using Domain.Common.Mediators.Events;

namespace Domain.RecipesDetails.Ingredients.Events.Updated
{
	public class IngredientUpdatedEvent : IEvent
	{
		public IngredientUpdatedEvent(Guid id)
		{
			Id = id;
		}

		public Guid Id { get; }
	}
}