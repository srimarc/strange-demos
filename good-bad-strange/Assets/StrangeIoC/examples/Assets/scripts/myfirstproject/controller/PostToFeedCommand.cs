using System;
using strange.examples.service;
using strange.examples.service.social;
using strange.extensions.command.impl;

namespace strange.examples.myfirstproject
{
	public class PostToFeedCommand : EventCommand
	{
		[Inject]
		public ISocialService service{ get; set; }

		[Inject]
		public IFeedData feedData{ get; set; }

		public override void Execute ()
		{
			string story = evt.data as string;

			if (story == null) {
				throw new Exception ("PostToFeedCommand received called without story content");
			}

			feedData.storyText = story;

			service.PostToFeed (feedData);
		}
	}
}

