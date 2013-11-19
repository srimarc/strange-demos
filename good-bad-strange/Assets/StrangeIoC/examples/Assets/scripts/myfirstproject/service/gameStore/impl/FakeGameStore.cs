using System;
using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;

namespace strange.examples.service.gameStore
{
	public class FakeGameStore : IGameStore
	{

		//THIS IS A FAKE VERSION OF AN APP STORE, FOR USE
		//IN EDITOR, WHERE YOU DON'T ACTUALLY HAVE ACCESS TO
		//A DEVICE'S STORE SDK.

		//IT SATIDFIES THE INTERFACE AND PROVIDES FEEDBACK FOR
		//AUTHORING CONVENIENCE AND TESTING.

		[Inject(ContextKeys.CONTEXT_DISPATCHER)]
		public IEventDispatcher dispatcher{ get; set; }

		public FakeGameStore ()
		{
		}

		#region IGameStore implementation

		public void PurchaseLevel (int levelId)
		{
			dispatcher.Dispatch (GameStoreEvent.PURCHASE_SUCCESS, "The level " + levelId + "was purchased");
		}

		#endregion
	}
}

