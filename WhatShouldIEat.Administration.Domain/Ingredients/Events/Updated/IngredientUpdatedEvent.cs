using System;
using WhatShouldIEat.Administration.Domain.Common.Events;

namespace WhatShouldIEat.Administration.Domain.Ingredients.Events.Updated
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