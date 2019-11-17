using System;
using System.Reflection;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities.MacroNutrients;

namespace WhatShouldIEat.Administration.Domain.Common.Helpers
{
	public static class AttributeHelper<T>
	{
		public static TA GetAttribute<TA>(T attributeOwner) where TA : MacroNutrientAttribute
			=> Attribute.GetCustomAttribute(ForValue(attributeOwner), typeof(TA)) as TA;

		private static MemberInfo ForValue(T attributeOwner)
			=> typeof(T).GetField(Enum.GetName(typeof(T), attributeOwner));
	}
}