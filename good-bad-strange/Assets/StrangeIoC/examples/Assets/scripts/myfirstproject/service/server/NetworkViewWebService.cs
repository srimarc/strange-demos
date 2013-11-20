using System;
using UnityEngine;
using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;

namespace strange.examples.service
{
	public class NetworkViewWebService : IWebService
	{
		[Inject(ContextKeys.CONTEXT_VIEW)]
		public GameObject contextView{ get; set; }

		[Inject]
		public IEventDispatcher dispatcher { get; set; }

		private NetworkView networkView;

		public NetworkViewWebService ()
		{
		}

		[PostConstruct]
		public void PostConstruct()
		{
			networkView = contextView.AddComponent<NetworkView> ();
		}

		public void Request(string data)
		{
			networkView.RPC (data, RPCMode.All);
		}
	}
}

