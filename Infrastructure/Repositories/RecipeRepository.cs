using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Recipes.Entities;
using Domain.Recipes.Queries.GetRecipesBasicInfos;
using Domain.Recipes.Repositories;
using Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
	public class RecipeRepository : IRecipeRepository
	{
		private readonly AdministrationDbContext _context;

		public RecipeRepository(AdministrationDbContext context) => 
			_context = context;

		public void Commit() => _context.SaveChanges();
		public void Add(Recipe recipe) => _context.Add(recipe);
		public void Delete(Recipe recipe) => _context.Remove(recipe);
		public bool ExistById(Guid id) => _context.Recipes.Any(x => x.Id == id);
		public bool ExistByName(string name) => _context.Recipes.Any(x => x.Name == name);

		public IEnumerable<Recipe> GetAll() =>
			_context.Recipes
				.Include(x => x.RecipeIngredients)
					.ThenInclude(x => x.Ingredient)
						.ThenInclude(x => x.MacroNutrientsParticipants)
				.ToList();

		public IEnumerable<Recipe> GetRecipesByIngredientId(Guid id) =>
			_context.Recipes
				.Include(x => x.RecipeIngredients)
					.ThenInclude(x => x.Ingredient)
						.ThenInclude(x => x.MacroNutrientsParticipants)
				.Where(x => x.RecipeIngredients.Any(y => y.Ingredient.Id == id))
				.ToList();

		public ICollection<RecipeBasicInfo> GetBasicInfos() =>
			_context.Recipes
				.Select(x => new RecipeBasicInfo(x.Id, x.Name))
				.ToList();

		public Recipe GetById(Guid id) =>
			_context.Recipes
				.Include(x => x.RecipeIngredients)
					.ThenInclude(x => x.Ingredient)
						.ThenInclude(x => x.MacroNutrientsParticipants)
				.FirstOrDefault(x => x.Id == id);

		public ICollection<RecipeBasicInfo> GetRecipesBasicInfosByIngredientId(Guid ingredientId) =>
			_context.Recipes
				.Include(ri => ri.RecipeIngredients)
				.Where(x => x.RecipeIngredients.Any(y => y.IngredientId == ingredientId))
				.Select(rbi => new RecipeBasicInfo(rbi.Id, rbi.Name))
				.ToList();
	}
}