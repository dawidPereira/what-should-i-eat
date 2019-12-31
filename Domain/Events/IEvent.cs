using System;
using Domain.Common.ValueObjects;

namespace Domain.Events
{
	public interface IEvent<T> : IEquatable<T>
	{
		Identity<Guid> Id { get; }
		
		DateTime CreatedDate { get; }
		
		string Data { get; }
		
		string Name { get; }
	}
}