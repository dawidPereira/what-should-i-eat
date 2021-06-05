using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Recipes.Entities;
using Domain.Recipes.Queries.GetBasicInfos;
using Domain.Recipes.Repositories;
using Infrastructure.Mappers.Recipes;
using Infrastructure.Repositories.DataAccess.Recipes;

namespace Infrastructure.Repositories
{
	public class RecipeRepositoryAdapter : IRecipeRepository
	{
		private readonly IRecipeMapper _recipeMapper;
		private readonly IRecipeDataReader _recipeDataReader;
		private readonly IRecipeDataWriter _recipeDataWriter;

		public RecipeRepositoryAdapter(IRecipeMapper recipeMapper,
			IRecipeDataReader recipeDataReader,
			IRecipeDataWriter recipeDataWriter)
		{
			_recipeMapper = recipeMapper;
			_recipeDataReader = recipeDataReader;
			_recipeDataWriter = recipeDataWriter;
		}

		public async Task Commit() => await _recipeDataWriter.Commit();

		public async Task Add(Recipe recipe) => await _recipeDataWriter.Add(
			Entities.Recipe.Recipe.FromDomainRecipe(recipe));

		public void Update(Recipe recipe) => _recipeDataWriter.Update(
			Entities.Recipe.Recipe.FromDomainRecipe(recipe));

		public void Remove(Recipe recipe) => _recipeDataWriter.Remove(
			Entities.Recipe.Recipe.FromDomainRecipe(recipe));

		public bool ExistById(Guid id) => _recipeDataReader.ExistById(id);

		public bool ExistByName(string name) => _recipeDataReader.ExistByName(name);

		public IEnumerable<Guid> GetAllIds() => _recipeDataReader.GetAll()
			.Select(x => x.Id)
			.ToList();

		public IDictionary<Guid, double> GetRecipeIngredientsById(Guid id) => _recipeDataReader
			.GetRecipeIngredientsById(id)
			.ToDictionary(x => x.IngredientId, x => x.Grams);

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
