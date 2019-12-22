using Domain.Recipes.Entities;
using Domain.RecipesDetails.Ingredients.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DbContexts
{
	public sealed class AdministrationDbContext : DbContext
	{
		public AdministrationDbContext(DbContextOptions<AdministrationDbContext> options)
			: base(options)
		{
		}
		
		public DbSet<Recipe> Recipes { get; set; }
		public DbSet<Ingredient> Ingredients { get; set; }
		public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
		
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