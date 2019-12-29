using System;
using Domain.Common.ValueObjects;
using Domain.Ingredients.Repositories;
using Domain.Recipes.Factories;

namespace Domain.Recipes.Entities
{
	public class RecipeIngredient : IValueObject<RecipeIngredient>
	{
		private RecipeIngredient(Identity<Guid> ingredientId, double grams)
		{
			IngredientId = ingredientId;
			Grams = grams;
		}

		public Identity<Guid> IngredientId { get; }
		public double Grams { get; }

		public bool Equals(RecipeIngredient other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return IngredientId.Equals(other.IngredientId) && Grams.Equals(other.Grams);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((RecipeIngredient) obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return (IngredientId.GetHashCode() * 397) ^ Grams.GetHashCode();
			}
		}
		
		public class RecipeIngredientFactory : IRecipeIngredientFactory
		{
			private readonly IIngredientRepository _ingredientRepository;

			public RecipeIngredientFactory(IIngredientRepository ingredientRepository)
			{
				_ingredientRepository = ingredientRepository;
			}

			public RecipeIngredient Create(Guid ingredientId, double grams)
			{
				if (grams <= 0)
					throw new ArgumentException("Cant add ingredients with grams lower than zero.");

				var id = new Identity<Guid>(ingredientId);
				return _ingredientRepository.ExistById(id.Value)
					? new RecipeIngredient(id, grams)
					: throw new ArgumentNullException($"Ingredient with Id:{ingredientId} does not exist.");
			}
		}
	}
}