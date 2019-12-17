using Domain.Common.ValueObjects;

namespace Domain.Ingredients.Entities.MacroNutrients
{
	public struct Share : IValueObject<Share>
	{
		public Share(MacroNutrient macroNutrient, double participationInIngredient)
		{
			MacroNutrient = macroNutrient;
			ParticipationInIngredient = participationInIngredient;
		}

		public MacroNutrient MacroNutrient { get;}
		public double ParticipationInIngredient { get;}

		public bool Equals(Share other) => 
			MacroNutrient == other.MacroNutrient && ParticipationInIngredient.Equals(other.ParticipationInIngredient);

		public override bool Equals(object obj) => 
			obj is Share other && Equals(other);

		public override int GetHashCode()
		{
			unchecked
			{
				return ((int) MacroNutrient * 397) ^ ParticipationInIngredient.GetHashCode();
			}
		}
	}
}