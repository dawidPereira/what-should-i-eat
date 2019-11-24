namespace WhatShouldIEat.Administration.Domain.Common.ValueObjects
{
	public class Result
	{
		private Result(bool isSuccess, string message, int httpCode)
		{
			IsSuccess = isSuccess;
			IsFailure = !isSuccess;
			Message = message;
		}

		public string Message { get; }
		public bool IsFailure { get; }
		public bool IsSuccess { get; }
		public string HttpCode { get; }

		public static Result Fail(string message, int httpCode) => new Result(false, message, httpCode);

		public static Result Ok(int httpCode) => new Result(true, "", httpCode);
	}
}