namespace WhatShouldIEat.Administration.Domain.Common.Events
{
	public interface IEventHandler<in TEvent> where TEvent : IEvent
	{
		void Handle(TEvent @event);
	}
}