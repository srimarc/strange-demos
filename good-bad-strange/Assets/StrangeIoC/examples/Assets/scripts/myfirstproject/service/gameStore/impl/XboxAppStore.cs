using System;
using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;

namespace strange.examples.service.gameStore
{
	public class XboxAppStore : IGameStore
	{
		[Inject(ContextKeys.CONTEXT_DISPATCHER)]
		public IEventDispatcher dispatcher{ get; set; }

		#region IGameStore implementation

		public void PurchaseLevel (int levelId)
		{
			//Here we'd make the call to the AppStoreSDK.
			//We'd fire the dispatcher on the callback.
		}

		#endregion
	}
}

