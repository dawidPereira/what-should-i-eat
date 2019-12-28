using Infrastructure.Entities.Ingredients;

namespace Infrastructure.Mappers
{
	public interface IIngredientMapper
	{
		Domain.Ingredients.Entities.Ingredient ToDomainIngredient(Ingredient ingredient);
	}
}