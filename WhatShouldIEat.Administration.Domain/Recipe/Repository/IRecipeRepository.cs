
namespace WhatShouldIEat.Administration.Domain.Recipe.Repository
{
	using Recipe = Entities.Recipe.Recipe;

	public interface IRecipeRepository
	{
		void Add(Recipe recipe);
		void Commit();
		bool ExistByName(string name);
		bool ExistById(string id);
	}
}