using Domain.Common.ValueObjects;

namespace Domain.Common.Command
{
	public interface ICommandHandler<in TCommand> where TCommand : ICommand
	{
		Result Handle(TCommand command);
	}
}