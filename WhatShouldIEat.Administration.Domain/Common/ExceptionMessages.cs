namespace WhatShouldIEat.Administration.Domain.Common
{
	public static class ExceptionMessages
	{
		public const string ValueCannotBeNull = "Value cannot be null.";
		public const string ValueCannotBeLowerThanZero = "Value cannot be lower than zero.";

		public static string NotFound(string id) => $"Item with Id: {id} does not exist.";
	}
}