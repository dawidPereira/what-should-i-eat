namespace WhatShouldIEat.Administration.Api.Validators
{
	public static class ErrorMessages
	{
		public static string Required(string parameterName) => $"{parameterName} is required.";
		public static string GreaterThanZero(string parameterName) => $"{parameterName} must be greater than zero.";
		public static string NotEmpty(string parameterName) => $"{parameterName} cannot be empty.";
	}
}