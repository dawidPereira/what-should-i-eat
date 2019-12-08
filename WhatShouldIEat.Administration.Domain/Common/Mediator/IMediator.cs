
using WhatShouldIEat.Administration.Domain.Common.Command;
using WhatShouldIEat.Administration.Domain.Common.Events;
using WhatShouldIEat.Administration.Domain.Common.Query;
using WhatShouldIEat.Administration.Domain.Common.ValueObjects;

namespace WhatShouldIEat.Administration.Domain.Common.Mediator
{
	public interface IMediator
	{
		Result Command<TCommand>(TCommand command) where TCommand : ICommand;

		void Publish<TEvent>(TEvent @event) where TEvent : IEvent;

		TResponse Query<TResponse>(IQuery<TResponse> query);

		TResponse Query<TQuery, TResponse>(TQuery query) where TQuery : IQuery<TResponse>;
	}
}