using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Recipes.Entities;
using Domain.Recipes.Queries.GetBasicInfos;
using Domain.Recipes.Repositories;
using Infrastructure.DbContexts;
using Infrastructure.Mappers;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
	public class RecipeRepository : IRecipeRepository
	{
		private readonly AdministrationDbContext _context;
		private readonly IRecipeMapper _recipeMapper;

		public RecipeRepository(AdministrationDbContext context, IRecipeMapper recipeMapper)
		{
			_context = context;
			_recipeMapper = recipeMapper;
		}

		public void Commit() => _context.SaveChanges();

		public void Add(Recipe recipe) => _context.Add(Entities.Recipe.Recipe.FromDomainRecipe(recipe));

		public void Update(Recipe recipe) => _context.Update(Entities.Recipe.Recipe.FromDomainRecipe(recipe));

		public void Remove(Recipe recipe) => _context.Remove(Entities.Recipe.Recipe.FromDomainRecipe(recipe));

		public bool ExistById(Guid id) => _context.Recipes.Any(x => x.Id == id);

		public bool ExistByName(string name) => _context.Recipes.Any(x => x.Name == name);

		public IEnumerable<Recipe> GetAll() => _context.Recipes
				.Include(x => x.RecipeIngredients)
				.Select(x => _recipeMapper.ToDomainRecipe(x))
				.ToList();

		public ICollection<RecipeBasicInfo> GetBasicInfos() => _context.Recipes
				.Select(x => new RecipeBasicInfo(x.Id, x.Name))
				.ToList();

		public Recipe GetById(Guid id) => _context.Recipes
				.Include(x => x.RecipeIngredients)
				.Where(x => x.Id == id)
				.Select(x => _recipeMapper.ToDomainRecipe(x))
				.FirstOrDefault();

		public ICollection<RecipeBasicInfo> GetRecipesBasicInfosByIngredientId(Guid ingredientId) => _context.Recipes
			.Include(x => x.RecipeIngredients)
			.Where(x => x.RecipeIngredients
				.Any(y => y.IngredientId == ingredientId))
			.Select(x => new RecipeBasicInfo(x.Id, x.Name))
			.ToList();
	}
}