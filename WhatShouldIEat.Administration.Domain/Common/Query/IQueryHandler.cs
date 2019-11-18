using WhatShouldIEat.Administration.Domain.Common.Query;

namespace WhatShouldIEat.Administration.Domain.Common.Query
{
	public interface IQueryHandler<in TQuery, out TResult> where TQuery : IQuery<TResult>
	{
		TResult Handle(TQuery query);
	}
}