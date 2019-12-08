using System;

namespace WhatShouldIEat.Administration.Api.Cache
{
	public interface IRecipeSearchInfoCacheProvider
	{
		void AddSearchInfo(Guid id);
		void BuildRecipeSearchInfo();
		void UpdateRecipeSearchInfoByIngredientId(Guid id);
	}
}