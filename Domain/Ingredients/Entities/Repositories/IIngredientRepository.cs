namespace Domain.Ingredients.Entities.Repositories
{
	public interface IIngredientRepository
	{
		bool ExistByName(string name);
	}
}