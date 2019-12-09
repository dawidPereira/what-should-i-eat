namespace Domain.Common.Messages
{
	public static class FailMessages
	{
		public static string AlreadyExist(string paramName, string valueType, string value) =>
			$"{paramName} with {valueType} = {value} already exist.";
		
		public static string DoesNotExist(string paramName, string valueType, string value) =>
			$"{paramName} with {valueType} = {value} does not exist.";

	}
}