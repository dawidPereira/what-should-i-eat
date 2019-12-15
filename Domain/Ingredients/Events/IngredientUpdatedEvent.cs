using Domain.Common.Mediators.Events;

namespace Domain.Ingredients.Events
{
	public class IngredientUpdatedEvent : Event
	{
		public IngredientUpdatedEvent(string queueName, string ingredientId) : base(queueName) 
			=> IngredientId = ingredientId;

		public string IngredientId { get; }
	}
}