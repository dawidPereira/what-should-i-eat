using System;
using Domain.Common.ValueObjects;

namespace Domain.Common.Mediators.Events
{
	public class Event : IEvent<Event>
	{
		public Event(string data, string name)
		{
			Name = name;
			Id = new Identity<Guid>(Guid.NewGuid());
			CreatedDate = DateTime.Now;
			ProcessedDate = null;
			Data = data;
			IsProcessed = false;
			
		}

		public Identity<Guid> Id { get; }
		public DateTime CreatedDate { get; }
		public DateTime? ProcessedDate { get; private set; }
		public string Data { get; }
		public string Name { get; }
		public bool IsProcessed { get; private set; }
		
		public void Process()
		{
			IsProcessed = true;
			ProcessedDate = DateTime.Now;
		}

		public bool Equals(Event other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return Id.Equals(other.Id) 
			       && CreatedDate.Equals(other.CreatedDate) 
			       && Nullable.Equals(ProcessedDate, other.ProcessedDate) 
			       && Data == other.Data && Name == other.Name 
			       && IsProcessed == other.IsProcessed;
		}

		public override bool Equals(object obj) => 
			ReferenceEquals(this, obj) || obj is Event other && Equals(other);

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = Id.GetHashCode();
				hashCode = (hashCode * 397) ^ CreatedDate.GetHashCode();
				hashCode = (hashCode * 397) ^ ProcessedDate.GetHashCode();
				hashCode = (hashCode * 397) ^ (Data != null ? Data.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ IsProcessed.GetHashCode();
				return hashCode;
			}
		}
	}
}