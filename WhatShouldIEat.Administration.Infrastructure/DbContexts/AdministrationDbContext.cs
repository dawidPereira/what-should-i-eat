using Microsoft.EntityFrameworkCore;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities;
using WhatShouldIEat.Administration.Domain.Recipes.Entities;

namespace WhatShouldIEat.Administration.Infrastructure.DbContexts
{
	public class AdministrationDbContext : DbContext
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