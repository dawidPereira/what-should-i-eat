using Infrastructure.Entities.Events;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DbContexts
{
	internal static class EventsModelBuilder
	{
		public static ModelBuilder ConfigureEvents(this ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<OutboxEvent>()
				.HasKey(key => key.Id);
			
			return modelBuilder;
		}
	}
}