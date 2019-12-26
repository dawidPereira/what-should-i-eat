using Domain.Common.Mediators.Commands;
using Domain.Common.Mediators.Queries;
using Domain.Common.ValueObjects;

namespace Domain.Common.Mediators
{
	public interface IMediator
	{
		Result Command<TCommand>(TCommand command) where TCommand : ICommand;

		TResponse Query<TResponse>(IQuery<TResponse> query);

		TResponse Query<TQuery, TResponse>(TQuery query) where TQuery : IQuery<TResponse>;
	}
}