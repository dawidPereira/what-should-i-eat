using System;

namespace WhatShouldIEat.Administration.Domain.Common.Validators
{
	public static class GramsValidator
	{
		public static void ThrowExceptionIfLowerThanZero(this double grams)
		{
			if (grams < 0)
				throw new ArgumentOutOfRangeException(nameof(grams), grams,
					"Value cannot be lower than zero.");
		}
	}
}