using System;

namespace strange.examples.service.social
{
	public interface IFeedData
	{
		string serviceName{ get; set; }

		string userName{ get; set; }

		string userId{ get; set; }

		string storyText{ get; set; }

		byte[] imageData{ get; set; }

		string linkUrl{ get; set; }
	}
}

