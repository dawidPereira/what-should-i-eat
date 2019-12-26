using System.Collections.Generic;
using Domain.RecipesDetails.Filters.FiltersCriteria;

namespace Domain.Common.Filters
{
	public interface IFilterFactory<TFilter, in TCriteria> 
		where TFilter : new()
		where  TCriteria : IFilterCriteria
	{
		ICollection<IFilter<TFilter>> Build(TCriteria filterCriteria);
	}
}