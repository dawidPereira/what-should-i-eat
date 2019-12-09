using Domain.Common.Command;
using Domain.Common.Query;
using Domain.Common.ValueObjects;

namespace Infrastructure.Mediator
{
	public interface IMediator
	{
		Result Command<TCommand>(TCommand command) where TCommand : ICommand;

		TResponse Query<TResponse>(IQuery<TResponse> query);

		TResponse Query<TQuery, TResponse>(TQuery query) where TQuery : IQuery<TResponse>;
	}
}