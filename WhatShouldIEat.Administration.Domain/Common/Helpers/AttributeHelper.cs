using System;
using System.Reflection;

namespace WhatShouldIEat.Administration.Domain.Common.Helpers
{
	public static class AttributeHelper<T>
	{
		public static TA GetAttribute<TA>(T attributeOwner) where TA : Attribute
			=> Attribute.GetCustomAttribute(ForValue(attributeOwner), typeof(T)) as TA;
		private static MemberInfo ForValue(T attributeOwner) 
			=> typeof(T).GetField(Enum.GetName(typeof(T), attributeOwner));
	}
}