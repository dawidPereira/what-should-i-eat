using Domain.Common.ValueObjects;
using Domain.Mediators.Command;
using Domain.Mediators.Query;

namespace Infrastructure.Mediator
{
	public interface IMediator
	{
		Result Command<TCommand>(TCommand command) where TCommand : ICommand;

		TResponse Query<TResponse>(IQuery<TResponse> query);

		TResponse Query<TQuery, TResponse>(TQuery query) where TQuery : IQuery<TResponse>;
	}
}