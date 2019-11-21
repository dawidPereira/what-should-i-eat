using WhatShouldIEat.Administration.Domain.Common.ValueObjects;

namespace WhatShouldIEat.Administration.Domain.Common.Command
{
	public interface ICommandHandler<in TCommand> where TCommand : ICommand
	{
		Result Handle(TCommand command);
	}
}