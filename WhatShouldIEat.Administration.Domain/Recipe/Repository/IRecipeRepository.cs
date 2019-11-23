﻿
using System;

namespace WhatShouldIEat.Administration.Domain.Recipe.Repository
{
	using Recipe = Entities.Recipe.Recipe;

	public interface IRecipeRepository
	{
		Recipe GetById(Guid id);
		void Add(Recipe recipe);
		void Update(Recipe recipe);
		void Commit();
		void Delete(Recipe recipe);
		bool ExistByName(string name);
		bool ExistById(Guid id);
	}
}