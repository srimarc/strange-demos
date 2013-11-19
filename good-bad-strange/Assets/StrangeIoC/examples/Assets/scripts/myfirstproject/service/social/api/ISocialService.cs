using System;

namespace strange.examples.service.social
{
	public interface ISocialService
	{
		string name{ get; }

		void PostToFeed(FeedData data);

		void FetchCurrentUser();

		void FetchScoresForFriends();
	}
}

