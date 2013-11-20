using System;
using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;

namespace strange.examples.service.social
{
	public class FacebookService : ISocialService
	{

		//Most things here are likely to be asynchronous. Use this injected dispatcher
		//To inform listeners that calls to the service have completed.
		[Inject(ContextKeys.CONTEXT_DISPATCHER)]
		public IEventDispatcher dispatcher{ get; set; }

		public FacebookService ()
		{
		}

		[PostConstruct]
		public void PostConstruct()
		{
			//Note that we can run a construction-style operation AFTER injection of properties
			//FB.Init();

			//This Class might get really messy with all your Facebook hijinks.
			//That's not so bad, so long as the mess stays inside the Class.
			//The rest of your app can be insulated from the mess...
			//...and since there are no Unity depedendencies here, you can
			//Unit Test this code.
		}

		#region ISocialService implementation

		//Identify this social service
		public string name {
			get {
				return SocialServices.FACEBOOK.ToString ();
			}
		}

		public void PostToFeed (IFeedData data)
		{
			//work here with the Facebook SDK to post to the timeline.
		}

		public void FetchCurrentUser ()
		{
			//work here with the Facebook SDK to get current user data
		}

		public void FetchScoresForFriends ()
		{
			//work here with the Facebook SDK to get the user's friends' scores
		}

		#endregion
	}
}

