﻿using System;
using Domain.Common.Mediators.Events;

namespace Domain.RecipesDetails.Recipes.Events.Deleted
{
	public class RecipeDeletedEvent : IEvent
	{
		public RecipeDeletedEvent(Guid id) => Id = id;

		public Guid Id { get;}
	}
}