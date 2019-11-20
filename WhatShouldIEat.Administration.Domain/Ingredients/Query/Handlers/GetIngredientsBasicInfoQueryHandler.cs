using System.Collections.Generic;
using WhatShouldIEat.Administration.Domain.Common.Query;
using WhatShouldIEat.Administration.Domain.Dto.IngredientsDto;
using WhatShouldIEat.Administration.Domain.Ingredients.Repositories;

namespace WhatShouldIEat.Administration.Domain.Ingredients.Query.Handlers
{
	public class GetIngredientsBasicInfoQueryHandler : 
		IQueryHandler<GetIngredientsBasicInfoQuery, ICollection<IngredientBasicInfo>>
	{
		private readonly IIngredientRepository _ingredientRepository;

		public GetIngredientsBasicInfoQueryHandler(IIngredientRepository ingredientRepository) => _ingredientRepository = ingredientRepository;

		public ICollection<IngredientBasicInfo> Handle(GetIngredientsBasicInfoQuery query) => _ingredientRepository.GetAllBasicInfos();
	}
}