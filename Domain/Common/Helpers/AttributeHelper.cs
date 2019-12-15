using System;
using System.Reflection;

namespace Domain.Common.Helpers
{
	public static class AttributeHelper<T>
	{
		public static TAttribute GetAttribute<TAttribute>(T attributeOwner) where TAttribute : Attribute
			=> Attribute.GetCustomAttribute(ForValue(attributeOwner), typeof(TAttribute)) as TAttribute;

		private static MemberInfo ForValue(T attributeOwner)
			=> typeof(T).GetField(Enum.GetName(typeof(T), attributeOwner));
	}
}