using System;
using System.Text.RegularExpressions;

namespace Domain.Common.Extensions
{
	public static class GuidExtensions
	{
		public static bool HasGuidValue(this Guid expression)
		{
			if (expression.ToString() == string.Empty) return false;
			var guidRegEx = new Regex(
				@"^(\{{0,1}([0-9a-fA-F]){8}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){12}\}{0,1})$");
			return guidRegEx.IsMatch(expression.ToString());
		}
	}
}