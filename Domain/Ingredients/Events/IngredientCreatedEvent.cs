using System;
using Domain.Common.Mediators.Events;
using Domain.Common.ValueObjects;

namespace Domain.Ingredients.Events
{
	public class IngredientCreatedEvent : IEvent<IngredientCreatedEvent>
	{
		public IngredientCreatedEvent(Identity<Guid> ingredientId, string queueName)
		{
			EventIdentity = new EventIdentity(queueName);
			IngredientId = ingredientId;
		}

		public Identity<Guid> IngredientId { get; }
		public IEventIdentity EventIdentity { get; }

		public bool Equals(IngredientCreatedEvent other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return Equals(EventIdentity, other.EventIdentity) && IngredientId.Equals(other.IngredientId);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			return obj.GetType() == GetType() && Equals((IngredientCreatedEvent) obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return ((EventIdentity != null ? EventIdentity.GetHashCode() : 0) * 397) ^ IngredientId.GetHashCode();
			}
		}
	}
}