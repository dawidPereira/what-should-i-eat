using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Ingredients.Entities;
using Domain.Ingredients.Repositories;
using Infrastructure.DbContexts;
using Infrastructure.Mappers;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
	public class IngredientRepository : IIngredientRepository
	{
		private readonly AdministrationDbContext _context;
		private readonly IIngredientMapper _ingredientMapper;

		public IngredientRepository(AdministrationDbContext context, IIngredientMapper ingredientMapper)
		{
			_context = context;
			_ingredientMapper = ingredientMapper;
		}

		public void Commit() => _context.SaveChanges();

		public bool ExistByName(string name) => _context.Ingredients.Any(x => x.Name == name);

		public bool ExistById(Guid id) => _context.Ingredients.Any(x => x.Id == id);

		public void Remove(Ingredient ingredient) => 
			_context.Remove(Entities.Ingredients.Ingredient.FromDomainIngredient(ingredient));

		public void Add(Ingredient ingredient) => 
			_context.Ingredients.Add(Entities.Ingredients.Ingredient.FromDomainIngredient(ingredient));

		public void Update(Ingredient ingredient) => 
			_context.Ingredients.Update(Entities.Ingredients.Ingredient.FromDomainIngredient(ingredient));

		public Ingredient GetById(Guid id) => _context.Ingredients
			.Include(x => x.MacroNutrientsShares)
			.Where(x => x.Id == id)
			.Select(x => _ingredientMapper.ToDomainIngredient(x))
			.FirstOrDefault();

		public ICollection<Ingredient> GetByIds(ICollection<Guid> ids) => _context.Ingredients
			.Include(x => x.MacroNutrientsShares)
			.Where(x => ids.Contains(x.Id))
			.Select(x => _ingredientMapper.ToDomainIngredient(x))
			.ToList();
	}
}