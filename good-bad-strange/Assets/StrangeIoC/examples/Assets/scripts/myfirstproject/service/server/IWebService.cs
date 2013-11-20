using System;
using strange.extensions.dispatcher.eventdispatcher.api;

namespace strange.examples.service
{
	public interface IWebService
	{
		void Request (string data);

		IEventDispatcher dispatcher { get; }
	}
}

