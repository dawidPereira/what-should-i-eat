using Domain.Common.ValueObjects;

namespace Domain.Common.Mediators.Commands
{
	public interface ICommandHandler<in TCommand> where TCommand : ICommand
	{
		Result Handle(TCommand command);
	}
}