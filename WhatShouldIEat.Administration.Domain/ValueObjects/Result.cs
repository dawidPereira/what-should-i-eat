namespace WhatShouldIEat.Administration.Domain.ValueObjects
{
	public class Result
	{
		private Result(bool isSuccess, string message)
		{
			IsSuccess = isSuccess;
			IsFailure = !isSuccess;
			Message = message;
		}

		public string Message { get; }
		public bool IsFailure { get; }
		public bool IsSuccess { get; }

		public static Result Fail(string message) => new Result(false, message);

		public static Result Ok() => new Result(true, "");
	}
}