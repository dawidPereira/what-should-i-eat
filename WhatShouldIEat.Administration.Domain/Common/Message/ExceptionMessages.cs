﻿namespace WhatShouldIEat.Administration.Domain.Common.Message
{
	public static class ExceptionMessages
	{
		public static string NotFound(string id) => $"Item with Id: {id} does not exist.";
	}
}