using System.Collections.Generic;
using Domain.RecipesDetails.Filters.FiltersCriteria;

namespace Domain.Common.Filters
{
	public interface IFilterFactory<TFilter, in TCriteria> 
		where TFilter : class 
		where  TCriteria : IFilterCriteria
	{
		ICollection<IFilter<TFilter>> BuildRecipeSearchFilters(TCriteria filterCriteria);
	}
}