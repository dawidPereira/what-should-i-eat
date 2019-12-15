namespace Domain.Ingredients.Entities.MacroNutirents
{
	public enum MacroNutrient
	{
		Default = 0,
		[MacroNutrient(4)] Carbohydrate = 1 << 1,
		[MacroNutrient(9)] Fat = 1 << 2,
		[MacroNutrient(4)] Protein = 1 << 3
	}
}