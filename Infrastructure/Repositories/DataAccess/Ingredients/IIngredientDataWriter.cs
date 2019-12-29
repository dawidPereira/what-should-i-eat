using Infrastructure.Entities.Ingredients;

namespace Infrastructure.Repositories.DataAccess.Ingredients
{
	public interface IIngredientDataWriter
	{
		void Commit();
		
		void Remove(Ingredient ingredient);
		
		void Add(Ingredient ingredient);
		
		void Update(Ingredient ingredient);
	}
}