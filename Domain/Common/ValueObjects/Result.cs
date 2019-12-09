using Domain.Common.Messages;

namespace Domain.Common.ValueObjects
{
	public class Result
	{
		private Result(bool isSuccess, ResultCode resultCode, string message)
		{
			IsSuccess = isSuccess;
			IsFailure = !isSuccess;
			Message = message;
			ResultCode = resultCode;
		}

		public string Message { get; }
		public bool IsFailure { get; }
		public bool IsSuccess { get; }
		public ResultCode ResultCode { get; }

		public static Result Fail(ResultCode resultCode, string message) => new Result(false, resultCode, message);

		public static Result Ok() => new Result(true, ResultCode.Success,"");
	}
}