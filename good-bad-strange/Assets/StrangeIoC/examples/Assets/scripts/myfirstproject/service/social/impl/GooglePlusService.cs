using System;
using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;

namespace strange.examples.service.social
{
	public class GooglePlusService : ISocialService
	{
		//Import the GooglePlus SDK here.

		//Most things here are likely to be asynchronous. Use this injected dispatcher
		//To inform listeners that calls to the service have completed.
		[Inject(ContextKeys.CONTEXT_DISPATCHER)]
		public IEventDispatcher dispatcher{ get; set; }

		public GooglePlusService ()
		{
		}

		#region ISocialService implementation

		//Identify this social service
		public string name {
			get {
				return SocialServices.GOOGLE_PLUS.ToString ();
			}
		}

		public void PostToFeed (FeedData data)
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

