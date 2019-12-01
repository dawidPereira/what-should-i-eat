using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WhatShouldIEat.Administration.Domain.Recipes.Entities;
using WhatShouldIEat.Administration.Domain.Recipes.Queries.GetRecuoesBasisInfos;
using WhatShouldIEat.Administration.Domain.Recipes.Repositories;
using WhatShouldIEat.Administration.Infrastructure.DbContexts;

namespace WhatShouldIEat.Administration.Infrastructure.Repositories
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

		public ICollection<RecipeBasicInfo> GetBasicInfos() =>
			_context.Recipes
				.Select(x => new RecipeBasicInfo(x.Id, x.Name))
				.ToList();

		public Recipe GetById(Guid id) =>
			_context.Recipes
				.Include(x => x.RecipeIngredients)
					.ThenInclude(x => x.Ingredient)
				.FirstOrDefault(x => x.Id == id);

		public ICollection<RecipeBasicInfo> GetRecipesBasicInfosByIngredientId(Guid ingredientId) =>
			_context.Recipes
				.Include(x => x.RecipeIngredients
					.Where(y => y.IngredientId == ingredientId))
				.Select(x => new RecipeBasicInfo(x.Id, x.Name))
				.ToList();
	}
}