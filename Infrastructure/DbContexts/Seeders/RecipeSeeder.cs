﻿using System;
using System.Collections.Generic;
using Domain.Recipes.Entities;
using Microsoft.EntityFrameworkCore;
using Recipe = Infrastructure.Entities.Recipe.Recipe;
using RecipeIngredient = Infrastructure.Entities.Recipe.RecipeIngredient;

namespace Infrastructure.DbContexts.Seeders
{
	public static class RecipeSeeder
	{
		public static ModelBuilder SeedRecipeData(this ModelBuilder modelBuilder)
		{
			var tempId = Guid.NewGuid();
			modelBuilder.Entity<Recipe>(property =>
				{
				property.HasData(new Recipe(tempId,
					"Oatmeal with milk",
					"Default recipe description",
					null, 
					null));
				property.OwnsOne(innerProperty => innerProperty.RecipeInfo)
					.HasData(new
					{
						RecipeId = tempId,
						DifficultyLevel = 2,
						PreparationTime = 15,
						ApproximateCost = 8m,
						MealTypes = MealType.Breakfast | MealType.Snack
					});
				});
			
			modelBuilder.Entity<RecipeIngredient>(property =>
				property.HasData(new List<RecipeIngredient>
					{
						new RecipeIngredient(new Guid(SeedConst.Oatmeal), tempId, 50),
						new RecipeIngredient(new Guid(SeedConst.Milk), tempId, 150)
					}));
			
			tempId = Guid.NewGuid();
			modelBuilder.Entity<Recipe>(property =>
			{
				property.HasData(new Recipe(tempId,
					"Chicken with rise",
					"Default recipe description",
					null,
					null));
				property.OwnsOne(innerProperty => innerProperty.RecipeInfo)
					.HasData(new
					{
						RecipeId = tempId,
						DifficultyLevel = 2,
						PreparationTime = 30,
						ApproximateCost = 10m,
						MealTypes = MealType.Dinner | MealType.Supper
					});
			});
			
			modelBuilder.Entity<RecipeIngredient>(property =>
				property.HasData(new List<RecipeIngredient>
				{
					new RecipeIngredient(new Guid(SeedConst.Chicken), tempId, 200),
					new RecipeIngredient(new Guid(SeedConst.Rice), tempId, 100)
				}));

			return modelBuilder;
		}
	}
}