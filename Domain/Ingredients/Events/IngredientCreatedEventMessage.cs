﻿using System;
using Domain.Events;
using Newtonsoft.Json.Linq;

namespace Domain.Ingredients.Events
{
	public class IngredientCreatedEventMessage : EventMessage
	{
		private new const string EventType = "IngredientCreatedEvent";
		
		private IngredientCreatedEventMessage(string message) 
			: base(message, EventType)
		{
		}

		public static IngredientCreatedEventMessage Create(Guid ingredientId) => 
			new IngredientCreatedEventMessage(BuildMessage(ingredientId));

		private static string BuildMessage(Guid ingredientId)
		{
			dynamic json = new JObject();
			json.ingredientId = ingredientId;
			return json.ToString();
		}
	}
}