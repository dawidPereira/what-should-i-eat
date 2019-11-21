using System;
using WhatShouldIEat.Administration.Domain.Common.Message;

namespace WhatShouldIEat.Administration.Domain.Common.Validators
{
	public static class NegativeDoubleValidator
	{
		public static void ThrowExceptionIfLowerThanZero(this double number, string parameterName)
		{
			if (number < 0)
				throw new ArgumentOutOfRangeException(parameterName, number,
					ExceptionMessages.ValueCannotBeLowerThanZero);
		}
	}
}