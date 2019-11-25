using System;
using WhatShouldIEat.Administration.Domain.Common.Messages;

namespace WhatShouldIEat.Administration.Domain.Common
{
	public static class Exceptions<T>
	{
		public static T ThrowNotFoundException(string paramName, string id) => 
			throw new ArgumentNullException(paramName, ExceptionMessages.NotFound( id));
	}
}