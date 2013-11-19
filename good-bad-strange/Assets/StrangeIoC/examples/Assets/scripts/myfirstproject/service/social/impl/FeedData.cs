using System;

namespace strange.examples.service.social
{
	public class FeedData : IFeedData
	{
		public string serviceName{ get; set; }

		public string userName{ get; set; }

		public string userId{ get; set; }

		public string storyText{ get; set; }

		public byte[] imageData{ get; set; }

		public string linkUrl{ get; set; }
	}
}

