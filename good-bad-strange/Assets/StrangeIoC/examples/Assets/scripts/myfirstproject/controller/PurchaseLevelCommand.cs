using System;
using strange.examples.service;
using strange.examples.service.social;
using strange.extensions.command.impl;
using strange.examples.service.gameStore;
using strange.extensions.dispatcher.eventdispatcher.api;

namespace strange.examples.myfirstproject
{
	public class PurchaseLevelCommand : EventCommand
	{
		[Inject]
		public IGameStore service{ get; set; }

		public override void Execute ()
		{
			Retain ();

			int level = (int)evt.data;

			service.dispatcher.AddListener (GameStoreEvent.PURCHASE_SUCCESS, OnSuccess);
			service.dispatcher.AddListener (GameStoreEvent.PURCHASE_FAILURE, OnFailure);

			service.PurchaseLevel (level);
		}

		private void OnSuccess()
		{
			//Report success

			ReleaseCommand ();
		}

		private void OnFailure(IEvent evt)
		{
			//Report failure

			ReleaseCommand ();
		}

		private void ReleaseCommand()
		{
			service.dispatcher.RemoveListener (GameStoreEvent.PURCHASE_SUCCESS, OnSuccess);
			service.dispatcher.RemoveListener (GameStoreEvent.PURCHASE_FAILURE, OnFailure);
			Release ();
		}
	}
}

