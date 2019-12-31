using Domain.Events;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DbContexts
{
	internal static class EventsModelBuilder
	{
		public static ModelBuilder ConfigureEvents(this ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Event>()
				.HasKey(key => key.Id);
			
			return modelBuilder;
		}
	}
}