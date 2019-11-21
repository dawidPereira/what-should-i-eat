using System;
using WhatShouldIEat.Administration.Domain.Common.Message;

namespace WhatShouldIEat.Administration.Domain.Common
{
	public static class Exceptions<T>
	{
		public static T ThrowNotFoundException(string paramName, string id) => 
			throw new ArgumentNullException(paramName, ExceptionMessages.NotFound( id));
	}
}