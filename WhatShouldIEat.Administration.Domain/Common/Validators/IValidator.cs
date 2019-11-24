using WhatShouldIEat.Administration.Domain.Common.ValueObjects;

namespace WhatShouldIEat.Administration.Domain.Common.Validators
{
	public interface IValidator<in TEntity> where TEntity : class
	{
		Result Validate(TEntity firstEntity);
	}
	
	public interface IValidator<in TEntity, in TEntity2> 
		where TEntity : class 
		where TEntity2 : class
	{
		Result Validate(TEntity firstEntity, TEntity2 secondEntity);
	}
}