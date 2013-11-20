using System;

namespace strange.examples.service.social
{
	public interface ISocialService
	{
		string name{ get; }

		void PostToFeed(IFeedData data);

		void FetchCurrentUser();

		void FetchScoresForFriends();
	}
}

