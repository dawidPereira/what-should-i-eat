using System.Threading.Tasks;
using Domain.Common.ValueObjects;

namespace Domain.Common.Mediators.Commands
{
	public interface ICommandHandler<in TCommand> where TCommand : ICommand
	{
		Task<Result> Handle(TCommand command);
	}
}
