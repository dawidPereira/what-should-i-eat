using Domain.Common.Messages;

namespace Domain.Common.ValueObjects
{
	public class Result : IValueObject<Result>
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

		public bool Equals(Result other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return Message == other.Message && IsFailure == other.IsFailure && IsSuccess == other.IsSuccess && ResultCode == other.ResultCode;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((Result) obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = (Message != null ? Message.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ IsFailure.GetHashCode();
				hashCode = (hashCode * 397) ^ IsSuccess.GetHashCode();
				hashCode = (hashCode * 397) ^ (int) ResultCode;
				return hashCode;
			}
		}
	}
}