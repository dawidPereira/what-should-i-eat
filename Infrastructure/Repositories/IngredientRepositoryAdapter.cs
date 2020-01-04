using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Ingredients.Entities;
using Domain.Ingredients.Repositories;
using Infrastructure.Mappers.Ingredients;
using Infrastructure.Repositories.DataAccess.Ingredients;

namespace Infrastructure.Repositories
{
	public class IngredientRepositoryAdapter : IIngredientRepository
	{
		private readonly IIngredientMapper _ingredientMapper;
		private readonly IIngredientDataReader _ingredientDataReader;
		private readonly IIngredientDataWriter _ingredientDataWriter;

		public IngredientRepositoryAdapter(IIngredientMapper ingredientMapper,
			IIngredientDataWriter ingredientDataWriter,
			IIngredientDataReader ingredientDataReader)
		{
			_ingredientMapper = ingredientMapper;
			_ingredientDataWriter = ingredientDataWriter;
			_ingredientDataReader = ingredientDataReader;
		}

		public void Commit() => _ingredientDataWriter.Commit();

		public void Remove(Ingredient ingredient) => _ingredientDataWriter.Remove(
			Entities.Ingredients.Ingredient.FromDomainIngredient(ingredient));

		public void Add(Ingredient ingredient) => _ingredientDataWriter.Add(
			Entities.Ingredients.Ingredient.FromDomainIngredient(ingredient));

		public void Update(Ingredient ingredient) => _ingredientDataWriter.Update(
			Entities.Ingredients.Ingredient.FromDomainIngredient(ingredient));

		public bool ExistByName(string name) => _ingredientDataReader.ExistByName(name);

		public bool ExistById(Guid id) => _ingredientDataReader.ExistById(id);

		public Ingredient GetById(Guid id) => _ingredientMapper.ToDomainIngredient(
				_ingredientDataReader.GetById(id), 
				this);

		public ICollection<Ingredient> GetByIds(ICollection<Guid> ids) =>
			_ingredientDataReader.GetByIds(ids)
				.Select(x => _ingredientMapper.ToDomainIngredient(x, this))
				.ToList();
	}
}