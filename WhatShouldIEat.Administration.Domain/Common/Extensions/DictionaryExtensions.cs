using System.Collections.Generic;
using System.Linq;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities.MacroNutrients;

namespace WhatShouldIEat.Administration.Domain.Common.Extensions
{
	public static class DictionaryExtensions
	{
		public static IDictionary<MacroNutrient, double> MergeDictionary(
			this IEnumerable<IDictionary<MacroNutrient, double>> source)
		{
			return source.Aggregate((acc, el) => acc
				.Concat(el)
				.GroupBy(o => o.Key)
				.ToDictionary(item => item.Key, item => item
					.Sum(o => o.Value)));
		}
	}
}