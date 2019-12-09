using System;
using Domain.Common.Messages;

namespace Domain.Common
{
	public static class Exceptions<T>
	{
		public static T ThrowNotFoundException(string paramName, string id) => 
			throw new ArgumentNullException(paramName, ExceptionMessages.NotFound( id));
	}
}