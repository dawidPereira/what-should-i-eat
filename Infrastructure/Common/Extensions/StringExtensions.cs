using System;

namespace Infrastructure.Common.Extensions
{
	public static class StringExtensions
	{
		public static T ToEnum<T>(this string enumString)
		{
			return (T) Enum.Parse(typeof (T), enumString);
		}
	}
}