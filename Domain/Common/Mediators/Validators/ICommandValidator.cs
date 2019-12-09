using Domain.Common.Mediators.Commands;
using Domain.Common.ValueObjects;

namespace Domain.Common.Mediators.Validators
{
	public interface ICommandValidator<in TCommand> where TCommand : ICommand
	{
		Result Validate(TCommand command);
	}
}