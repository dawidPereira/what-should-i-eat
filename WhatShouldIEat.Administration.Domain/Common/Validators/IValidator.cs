using WhatShouldIEat.Administration.Domain.Common.Command;
using WhatShouldIEat.Administration.Domain.Common.ValueObjects;

namespace WhatShouldIEat.Administration.Domain.Common.Validators
{
	public interface IValidator<in TCommand> where TCommand : ICommand
	{
		Result Validate(TCommand command);
	}
	
	public interface IValidator<in TCommand, in TEntity> where TCommand : ICommand where TEntity : class
	{
		Result Validate(TCommand command, TEntity entity);
	}
}