using Domain.Common.Mediators.Commands;
using Domain.Common.Messages;
using Domain.Common.ValueObjects;
using Domain.Events;
using Domain.Ingredients.Repositories;

namespace Domain.Ingredients.Commands.Delete
{
	public class DeleteIngredientCommandHandler : ICommandHandler<DeleteIngredientCommand>
	{
		private readonly IIngredientRepository _ingredientRepository;
		private readonly IEventPublisher _eventPublisher;

		public DeleteIngredientCommandHandler(IIngredientRepository ingredientRepository,
			IEventPublisher eventPublisher)
		{
			_ingredientRepository = ingredientRepository;
			_eventPublisher = eventPublisher;
		}

		public Result Handle(DeleteIngredientCommand command)
		{
			var ingredient = _ingredientRepository.GetById(command.Id);
			if (ingredient == null) 
				return Result.Fail(ResultCode.NotFound, $"Ingredient with {command.Id}, does not exist");
			ingredient.Delete();
			_eventPublisher.Rise();
			return Result.Ok();
		}
	}
}