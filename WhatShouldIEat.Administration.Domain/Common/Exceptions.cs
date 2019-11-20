using System;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities;

namespace WhatShouldIEat.Administration.Domain.Common
{
	public static class Exceptions<T>
	{
		public static T NotFound(string paramName, string id) => 
			throw new ArgumentNullException(paramName, ExceptionMessages.NotFound( id));
	}
}