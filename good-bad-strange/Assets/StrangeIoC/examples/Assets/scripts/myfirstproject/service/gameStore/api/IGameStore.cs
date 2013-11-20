using System;
using strange.extensions.dispatcher.eventdispatcher.api;

namespace strange.examples.service.gameStore
{
	public interface IGameStore
	{
		void PurchaseLevel(int levelId);

		IEventDispatcher dispatcher{ get; }
	}
}

