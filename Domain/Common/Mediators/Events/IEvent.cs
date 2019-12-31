using System;
using Domain.Common.ValueObjects;

namespace Domain.Common.Mediators.Events
{
	public interface IEvent<T> : IEquatable<T>
	{
		Identity<Guid> Id { get; }
		
		DateTime CreatedDate { get; }
		
		DateTime? ProcessedDate { get; }
		
		string Data { get; }
		
		string Name { get; }
		
		bool IsProcessed { get; }

		void Process();

	}
}