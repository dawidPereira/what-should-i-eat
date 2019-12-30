using Infrastructure.Entities.Ingredient;
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
		public DbSet<MacroNutrientShares> MacroNutrientShares { get; set; }
		
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder
				.ConfigureRecipe()
				.ConfigureIngredient()
				.ConfigureRecipeIngredient()
				.ConfigureIngredientMacroNutrient();
		}
	}
}