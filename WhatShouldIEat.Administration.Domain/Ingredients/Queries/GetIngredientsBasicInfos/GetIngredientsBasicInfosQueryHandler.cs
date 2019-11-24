using System.Collections.Generic;
using WhatShouldIEat.Administration.Domain.Common.Query;
using WhatShouldIEat.Administration.Domain.Ingredients.Repositories;

namespace WhatShouldIEat.Administration.Domain.Ingredients.Queries.GetIngredientsBasicInfos
{
	public class GetIngredientsBasicInfosQueryHandler : 
		IQueryHandler<GetIngredientsBasicInfosQuery, ICollection<IngredientBasicInfo>>
	{
		private readonly IIngredientRepository _ingredientRepository;

		public GetIngredientsBasicInfosQueryHandler(IIngredientRepository ingredientRepository) => 
			_ingredientRepository = ingredientRepository;

		public ICollection<IngredientBasicInfo> Handle(GetIngredientsBasicInfosQuery query) => 
			_ingredientRepository.GetAllBasicInfos() ?? new List<IngredientBasicInfo>();
	}
}