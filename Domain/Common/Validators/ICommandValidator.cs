using Domain.Common.ValueObjects;
using Domain.Mediators.Command;

namespace Domain.Common.Validators
{
	public interface ICommandValidator<in TCommand> where TCommand : ICommand
	{
		Result Validate(TCommand command);
	}
}