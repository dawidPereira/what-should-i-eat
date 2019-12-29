using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Recipes.Entities;
using Domain.Recipes.Queries.GetBasicInfos;
using Domain.Recipes.Repositories;
using Infrastructure.Mappers;
using Infrastructure.Repositories.DataAccess.Recipes;

namespace Infrastructure.Repositories
{
	public class RecipeRepositoryAdapter : IRecipeRepository
	{
		private readonly IRecipeMapper _recipeMapper;
		private readonly IRecipeDataReader _recipeDataReader;
		private readonly IRecipeDataWriter _recipeDataWriter;

		public RecipeRepositoryAdapter(IRecipeMapper recipeMapper, IRecipeDataReader recipeDataReader, IRecipeDataWriter recipeDataWriter)
		{
			_recipeMapper = recipeMapper;
			_recipeDataReader = recipeDataReader;
			_recipeDataWriter = recipeDataWriter;
		}

		public void Commit() => _recipeDataWriter.Commit();

		public void Add(Recipe recipe) => _recipeDataWriter.Add(
			Entities.Recipe.Recipe.FromDomainRecipe(recipe));

		public void Update(Recipe recipe) => _recipeDataWriter.Update(
			Entities.Recipe.Recipe.FromDomainRecipe(recipe));

		public void Remove(Recipe recipe) => _recipeDataWriter.Remove(
			Entities.Recipe.Recipe.FromDomainRecipe(recipe));

		public bool ExistById(Guid id) => _recipeDataReader.ExistById(id);

		public bool ExistByName(string name) => _recipeDataReader.ExistByName(name);

		public IEnumerable<Recipe> GetAll() => _recipeDataReader.GetAll()
			.Select(x => _recipeMapper.ToDomainRecipe(x, this))
			.ToList();

		public ICollection<RecipeBasicInfo> GetBasicInfos() => _recipeDataReader.GetBasicInfos()
			.ToList();

		public Recipe GetById(Guid id) => _recipeMapper.ToDomainRecipe(
			_recipeDataReader.GetById(id) ?? throw new ArgumentNullException($"Recipe with Id: {id} does not exist"),
			this);

		public ICollection<RecipeBasicInfo> GetRecipesBasicInfosByIngredientId(Guid ingredientId) => 
			_recipeDataReader.GetRecipesBasicInfosByIngredientId(ingredientId)
				.ToList();
	}
}