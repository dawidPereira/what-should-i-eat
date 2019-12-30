using System.Collections.Generic;
using System.Linq;

namespace Domain.Common.Extensions
{
	public static class DictionaryExtensions
	{
		public static IDictionary<int, double> MergeDictionary(
			this IEnumerable<IDictionary<int, double>> source)
		{
			return source.Aggregate((acc, el) => acc
				.Concat(el)
				.GroupBy(o => o.Key)
				.ToDictionary(item => item.Key, item => item
					.Sum(o => o.Value)));
		}
	}
}