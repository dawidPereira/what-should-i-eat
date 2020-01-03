using Infrastructure.Entities.Events;
using Infrastructure.Entities.Ingredients;
using Infrastructure.Entities.Recipe;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DbContexts
{
	public sealed class AdministrationDbContext : DbContext
	{
		public AdministrationDbContext(DbContextOptions options)
			: base(options)
		{
		}
		
		public DbSet<Recipe> Recipes { get; set; }
		public DbSet<Ingredient> Ingredients { get; set; }
		public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
		public DbSet<OutboxEvent> Events { get; set; }
		
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder
				.ConfigureEvents()
				.ConfigureRecipe()
				.ConfigureIngredient()
				.ConfigureRecipeIngredient()
				.ConfigureIngredientMacroNutrient();
		}
	}
}