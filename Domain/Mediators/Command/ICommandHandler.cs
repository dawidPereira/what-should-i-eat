using Domain.Common.ValueObjects;

namespace Domain.Mediators.Command
{
	public interface ICommandHandler<in TCommand> where TCommand : ICommand
	{
		Result Handle(TCommand command);
	}
}