namespace WhatShouldIEat.Administration.Api.Validators
{
	public static class ErrorMessages
	{
		public static string Required(string parameterName) => $"{parameterName} is required.";
		public static string NotEmpty(string parameterName) => $"{parameterName} cannot be empty.";
		public static string GreaterThan(string parameterName, int minValue) => 
			$"{parameterName} must be greater than: {minValue}.";
		public static string LowerThan(string parameterName, int maxValue) =>
			$"{parameterName} must be lower than: {maxValue}.";
		public static string GreaterOrEqualTo(string parameterName, int minValue) => 
			$"{parameterName} must be greater or equal to: {minValue}.";
		public static string LowerOrEqualTo(string parameterName, int maxValue) =>
			$"{parameterName} must be lower or equal to: {maxValue}.";
	}
}