using Domain.Common.Mediators.Commands;
using Domain.Common.Mediators.Events;
using Domain.Common.ValueObjects;
using Domain.Ingredients.Factories;
using Domain.Ingredients.Repositories;

namespace Domain.Ingredients.Commands.Create
{
	public class CreateIngredientCommandHandler : ICommandHandler<CreateIngredientCommand>
	{
		private readonly IIngredientRepository _ingredientRepository;
		private readonly IIngredientFactory _ingredientFactory;
		private readonly IEventPublisher _eventPublisher;

		public CreateIngredientCommandHandler(
			IIngredientRepository ingredientRepository, IIngredientFactory ingredientFactory, IEventPublisher eventPublisher)
		{
			_ingredientRepository = ingredientRepository;
			_ingredientFactory = ingredientFactory;
			_eventPublisher = eventPublisher;
		}

		public Result Handle(CreateIngredientCommand command)
		{
			 _ingredientFactory.Create(
				command.Id, command.Name, command.Allergens, command.Requirements, command.Shares, _eventPublisher);
			_eventPublisher.Rise(EventsQueue.IngredientCreated);
			return Result.Ok();
		}
	}
}