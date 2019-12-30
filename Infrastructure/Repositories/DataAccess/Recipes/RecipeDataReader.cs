using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Recipes.Queries.GetBasicInfos;
using Infrastructure.DbContexts;
using Infrastructure.Entities.Recipe;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.DataAccess.Recipes
{
	public class RecipeDataReader : IRecipeDataReader
	{
		private readonly AdministrationDbContext _context;

		public RecipeDataReader(AdministrationDbContext context)
		{
			_context = context;
		}
		
		public bool ExistById(Guid id) => _context.Recipes.Any(x => x.Id == id);

		public bool ExistByName(string name) => _context.Recipes.Any(x => x.Name == name);

		public IEnumerable<Recipe> GetAll() => _context.Recipes
			.Include(x => x.RecipeIngredients);

		public IEnumerable<RecipeBasicInfo> GetBasicInfos() => _context.Recipes
			.Select(x => new RecipeBasicInfo(x.Id, x.Name));

		public Recipe GetById(Guid id) => _context.Recipes
			.Include(x => x.RecipeIngredients)
			.FirstOrDefault(x => x.Id == id);

		public IEnumerable<RecipeIngredient> GetRecipeIngredientsById(Guid id) => _context.RecipeIngredients
			.Where(x => x.RecipeId == id);

		public IEnumerable<RecipeBasicInfo> GetRecipesBasicInfosByIngredientId(Guid ingredientId) => _context.Recipes
			.Include(x => x.RecipeIngredients)
			.Where(x => x.RecipeIngredients
				.Any(y => y.IngredientId == ingredientId))
			.Select(x => new RecipeBasicInfo(x.Id, x.Name));
	}
}