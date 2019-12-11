using System;

namespace Infrastructure.Common.Extensions
{
	public static  class GuidExtensions
	{
		public static string ToDictionaryKey(this Guid guid, string keyPrefix) => $"{keyPrefix}_{guid}";
	}
}