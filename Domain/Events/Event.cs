using System;
using Domain.Common.ValueObjects;

namespace Domain.Events
{
	public class Event : IEvent<Event>
	{
		public Event(string data, string name)
		{
			Name = name;
			Id = new Identity<Guid>(Guid.NewGuid());
			CreatedDate = DateTime.Now;
			Data = data;
			
		}

		public Identity<Guid> Id { get; }
		public DateTime CreatedDate { get; }
		public string Data { get; }
		public string Name { get; }
		
		public bool Equals(Event other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return Id.Equals(other.Id)
			       && CreatedDate.Equals(other.CreatedDate)
			       && Data == other.Data && Name == other.Name;
		}

		public override bool Equals(object obj) => 
			ReferenceEquals(this, obj) || obj is Event other && Equals(other);

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = Id.GetHashCode();
				hashCode = (hashCode * 397) ^ CreatedDate.GetHashCode();
				hashCode = (hashCode * 397) ^ (Data != null ? Data.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
				return hashCode;
			}
		}
	}
}