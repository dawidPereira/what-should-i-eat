using WhatShouldIEat.Administration.Domain.Common.Command;
using WhatShouldIEat.Administration.Domain.ValueObjects;

namespace WhatShouldIEat.Administration.Domain.Common.Command
{
	public interface ICommandHandler<in TCommand> where TCommand : ICommand
	{
		Result Handle(TCommand command);
	}
}