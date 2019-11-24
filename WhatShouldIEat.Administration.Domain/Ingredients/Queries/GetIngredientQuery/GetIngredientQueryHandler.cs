using WhatShouldIEat.Administration.Domain.Common;
using WhatShouldIEat.Administration.Domain.Common.Query;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities;
using WhatShouldIEat.Administration.Domain.Ingredients.Repositories;

namespace WhatShouldIEat.Administration.Domain.Ingredients.Queries.GetIngredientQuery
{
	public class GetIngredientQueryHandler : IQueryHandler<GetIngredientQuery, IngredientDto>
	{
		private readonly IIngredientRepository _ingredientRepository;

		public GetIngredientQueryHandler(IIngredientRepository ingredientRepository) =>
			_ingredientRepository = ingredientRepository;

		public IngredientDto Handle(GetIngredientQuery query) => _ingredientRepository.GetById(query.Id)?.ToDto() ??
			Exceptions<IngredientDto>.ThrowNotFoundException(nameof(Ingredient), query.Id.ToString());
	}
}