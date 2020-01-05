using System.Collections.Generic;

namespace Domain.Common.Filters
{
	public interface IFilterFactory<in TFilter, in TCriteria> 
		where TFilter : new()
		where  TCriteria : IFilterCriteria
	{
		IEnumerable<IFilter<TFilter>> Build(TCriteria filterCriteria);
	}
}