using Domain.Common.Command;
using Domain.Common.ValueObjects;

namespace Domain.Common.Validators
{
	public interface ICommandValidator<in TCommand> where TCommand : ICommand
	{
		Result Validate(TCommand command);
	}
}