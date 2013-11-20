using System;
using strange.extensions.context.api;

namespace strange.examples.service.social
{
	public class MultiSocialService : ISocialService, IMultiService
	{
		//WE INJECT THE TWO VERSIONS OF THE SERVICE...
		[Inject(SocialServices.FACEBOOK)]
		public ISocialService facebook{ get; set; }

		[Inject(SocialServices.GOOGLE_PLUS)]
		public ISocialService googlePlus{ get; set; }

		private ISocialService selectedService;

		public MultiSocialService ()
		{
		}

		//WE IMPLEMENT THE IMultipleSocialService INTERFACE...

		#region IMultiService implementation

		public void selectService (Enum id)
		{
			if (id.Equals(SocialServices.FACEBOOK)) 
			{
				selectedService = facebook;
			} 
			else if (id.Equals(SocialServices.GOOGLE_PLUS)) 
			{
				selectedService = googlePlus;
			} 
			else 
			{
				throw new Exception ("MultiSocialService received unrecognized service id.");
			}
		}

		#endregion

		//...EVERYTHING ELSE IS JUST FACADE!!!!

		#region ISocialService implementation

		//Identify this social service
		public string name 
		{
			get 
			{
				return selectedService.name;
			}
		}

		public void PostToFeed (IFeedData data)
		{
			selectedService.PostToFeed (data);
		}

		public void FetchCurrentUser ()
		{
			selectedService.FetchCurrentUser ();
		}

		public void FetchScoresForFriends ()
		{
			selectedService.FetchScoresForFriends ();
		}

		#endregion
	}
}

