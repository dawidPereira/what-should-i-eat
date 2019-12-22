using System;
using Domain.Common.Mediators.Events;
using Domain.Common.ValueObjects;

namespace Domain.Recipes.Events.Created
{
	public class RecipeCreatedEvent : IEvent<RecipeCreatedEvent>
	{
		public RecipeCreatedEvent(Identity<Guid> recipeId, string queueName)
		{
			EventIdentity = new EventIdentity(queueName);
			RecipeId = recipeId;
		}

		public Identity<Guid> RecipeId { get; }
		public IEventIdentity EventIdentity { get; }

		public bool Equals(RecipeCreatedEvent other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return RecipeId.Equals(other.RecipeId) && Equals(EventIdentity, other.EventIdentity);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			return obj.GetType() == GetType() && Equals((RecipeCreatedEvent) obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return (RecipeId.GetHashCode() * 397) ^ (EventIdentity != null ? EventIdentity.GetHashCode() : 0);
			}
		}
	}
}