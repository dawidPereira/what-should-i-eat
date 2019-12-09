using System;
using Domain.Common.Events;

namespace Domain.Recipes.Events.Deleted
{
	public class RecipeDeletedEvent : IEvent
	{
		public RecipeDeletedEvent(Guid id)
		{
			Id = id;
		}
		
		public Guid Id { get;}
	}
}