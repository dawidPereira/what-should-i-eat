using System;
using System.Collections.Generic;
using System.Linq;
using Domain.RecipesDetails.Ingredients.Entities;
using Domain.RecipesDetails.Ingredients.Queries.GetIngredientsBasicInfos;
using Domain.RecipesDetails.Ingredients.Repositories;
using Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
	public class IngredientRepository : IIngredientRepository
	{
		private readonly AdministrationDbContext _context;

		public IngredientRepository(AdministrationDbContext context) => 
			_context = context;
		
		public void Commit() => _context.SaveChanges();
		public void Remove(Ingredient ingredient) => _context.Remove(ingredient);
		public bool ExistById(Guid id) => _context.Ingredients.Any(x => x.Id == id);
		public void Add(Ingredient ingredient) => _context.Ingredients.Add(ingredient);
		public bool ExistByName(string name) => _context.Ingredients.Any(x => x.Name == name);
		public Ingredient GetById(Guid id) => _context.Ingredients.
			Include(x => x.MacroNutrientsParticipants)
			.FirstOrDefault(x => x.Id == id);

		public ICollection<IngredientBasicInfo> GetBasicInfos() =>
			_context.Ingredients
				.Select(x => new IngredientBasicInfo(x.Id, x.Name))
				.ToList();
	}
}