using System;
using WhatShouldIEat.Administration.Domain.Common.Events;

namespace WhatShouldIEat.Administration.Domain.Recipes.Events.Deleted
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