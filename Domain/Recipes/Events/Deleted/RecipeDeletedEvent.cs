using System;
using Domain.Mediators.Events;

namespace Domain.Recipes.Events.Deleted
{
	public class RecipeDeletedEvent : IEvent
	{
		public RecipeDeletedEvent(Guid id) => 
			Id = id;

		public Guid Id { get;}
	}
}