using System;
using Domain.Mediators.Events;

namespace Domain.Ingredients.Events.Updated
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