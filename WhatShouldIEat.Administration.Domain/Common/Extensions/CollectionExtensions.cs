using System;
using System.Collections;

namespace WhatShouldIEat.Administration.Domain.Common.Extensions
{
	public static class CollectionExtensions
	{
		public static void ForEach<T>(this ICollection @this, Action<T> action)
		{
			foreach (T item in @this)
			{
				action(item);
			}
		}
	}
}