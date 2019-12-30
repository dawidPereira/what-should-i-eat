using System;
using System.Collections.Generic;
using Domain.Common.ValueObjects;

namespace Domain.RecipesDetails.Entities
{
	public struct Recipe : IValueObject<Recipe>
	{
		public Recipe(Guid id, string name, string description, RecipeInfo recipeInfo, IDictionary<Guid, double> recipeIngredients)
		{
			Id = new Identity<Guid>(id);
			Name = name;
			Description = description;
			RecipeInfo = recipeInfo;
			RecipeIngredients = recipeIngredients;
		}
		public Identity<Guid> Id { get; }
		public string Name { get; }
		public string Description { get; }
		public RecipeInfo RecipeInfo { get; }
		public IDictionary<Guid, double> RecipeIngredients { get; }

		public bool Equals(Recipe other)
		{
			return Id.Equals(other.Id) 
			       && Name == other.Name 
			       && Description == other.Description 
			       && RecipeInfo.Equals(other.RecipeInfo) 
			       && Equals(RecipeIngredients, other.RecipeIngredients);
		}

		public override bool Equals(object obj)
		{
			return obj is Recipe other && Equals(other);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = Id.GetHashCode();
				hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (Description != null ? Description.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ RecipeInfo.GetHashCode();
				hashCode = (hashCode * 397) ^ (RecipeIngredients != null ? RecipeIngredients.GetHashCode() : 0);
				return hashCode;
			}
		}
	}
}