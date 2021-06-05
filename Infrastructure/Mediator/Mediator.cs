using System;
using System.Linq;
using System.Threading.Tasks;
using Domain.Common.Mediators;
using Domain.Common.Mediators.Commands;
using Domain.Common.Mediators.Queries;
using Domain.Common.ValueObjects;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Mediator
{
	public class Mediator : IMediator
	{
		private readonly IServiceProvider _serviceProvider;

		public Mediator(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

		public async Task<Result> Command<TCommand>(TCommand command) where TCommand : ICommand
		{
			var handler = _serviceProvider.GetService<ICommandHandler<TCommand>>();
			if (handler == null)
				throw new InvalidOperationException(
					$"Command of type '{command.GetType()}' has not registered handler.");

			return await handler.Handle(command);
		}

		public TResponse Query<TResponse>(IQuery<TResponse> query) =>
			(TResponse) GetType()
				.GetMethods()
				.First(x => x.Name == "Query" && x.GetGenericArguments().Length == 2)
				.MakeGenericMethod(query.GetType(), typeof(TResponse))
				.Invoke(this, new object[] {query});

		public TResponse Query<TQuery, TResponse>(TQuery query) where TQuery : IQuery<TResponse>
		{
			var handler = _serviceProvider.GetService<IQueryHandler<TQuery, TResponse>>();
			if (handler == null)
				throw new InvalidOperationException($"Query of type '{query.GetType()}' has not registered handler.");

			return handler.Handle(query);
		}
	}
}
