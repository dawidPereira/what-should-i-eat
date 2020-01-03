using Domain.Events;

namespace Domain.RecipesDetails.Events.Ingredients
{
	public class IngredientCreatedEventHandler : IEventHandler<IngredientCreatedEvent>
	{
		public void Handle(IngredientCreatedEvent @event)
		{
		}
	}
}