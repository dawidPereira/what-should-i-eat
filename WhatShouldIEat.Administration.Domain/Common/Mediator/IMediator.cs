
using WhatShouldIEat.Administration.Domain.Common.Command;
using WhatShouldIEat.Administration.Domain.Common.Query;
using WhatShouldIEat.Administration.Domain.ValueObjects;

namespace WhatShouldIEat.Administration.Domain.Common.Mediator
{
	public interface IMediator
	{
		Result Command<TCommand>(TCommand command) where TCommand : ICommand;

		TResponse Query<TResponse>(IQuery<TResponse> query);

		TResponse Query<TQuery, TResponse>(TQuery query) where TQuery : IQuery<TResponse>;
	}
}