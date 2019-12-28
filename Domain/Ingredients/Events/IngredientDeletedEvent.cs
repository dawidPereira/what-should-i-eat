using System;
using Domain.Common.Mediators.Events;

namespace Domain.Ingredients.Events
{
	public class IngredientDeletedEvent : IEvent<IngredientDeletedEvent>
	{
		public IngredientDeletedEvent(Guid ingredientId, string queueName)
		{
			IngredientId = ingredientId;
			EventIdentity = new EventIdentity(queueName);
		}
		
		public Guid IngredientId { get; }
		public IEventIdentity EventIdentity { get; }

		public bool Equals(IngredientDeletedEvent other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return IngredientId.Equals(other.IngredientId) && Equals(EventIdentity, other.EventIdentity);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			return obj.GetType() == GetType() && Equals((IngredientDeletedEvent) obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return (IngredientId.GetHashCode() * 397) ^ (EventIdentity != null ? EventIdentity.GetHashCode() : 0);
			}
		}
	}
}