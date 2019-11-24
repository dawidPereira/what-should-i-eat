using WhatShouldIEat.Administration.Domain.Common.Command;
using WhatShouldIEat.Administration.Domain.Common.ValueObjects;

namespace WhatShouldIEat.Administration.Domain.Common.Validators
{
	public interface ICommandValidator<in TCommand> where TCommand : ICommand
	{
		Result Validate(TCommand command);
	}
}