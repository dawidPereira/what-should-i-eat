using System;
using System.Reflection;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities.MacroNutrients;

namespace WhatShouldIEat.Administration.Domain.Common.Helpers
{
	public static class AttributeHelper<T>
	{
		public static TAttribute GetAttribute<TAttribute>(T attributeOwner) where TAttribute : MacroNutrientAttribute
			=> Attribute.GetCustomAttribute(ForValue(attributeOwner), typeof(TAttribute)) as TAttribute;

		private static MemberInfo ForValue(T attributeOwner)
			=> typeof(T).GetField(Enum.GetName(typeof(T), attributeOwner));
	}
}