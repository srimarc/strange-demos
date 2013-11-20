/// The Context is where all the magic really happens.
/// ===========
/// Other than copying the constructors, all you really need to do when you create
/// your context is override Context or one of its subclasses, then set up
/// your list of mappings.
/// 
/// In an MVCSContext, like the one we're using, there are three types of
/// available mappings:
/// 1. Dependency Injection - Bind your dependencies to injectionBinder.
/// 2. View/Mediator Binding - Bind MonoBehaviours on your GameObjects to Mediators that speak to the rest of the app
/// 3. Event Binding - Bind Events to any/all of the following:
/// 		- Event/Method Binding -	Firing the event will trigger the method(s).
/// 		- Event/Command Binding -	Firing the event will instantiate the Command(s) and run its Execute() method.
/// 		- Event/Sequence Binding -	Firing the event will instantiate a Command(s), run its Execute() method, and,
/// 									unless the sequence is interrupted, fire each subsequent Command until the
/// 									sequence is complete.

using System;
using UnityEngine;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.dispatcher.eventdispatcher.impl;
using strange.examples.service.social;
using strange.examples.service.gameStore;
using strange.examples.service;

namespace strange.examples.myfirstproject
{
	public class MyFirstContext : MVCSContext
	{
		
		
		public MyFirstContext () : base()
		{
		}
		
		public MyFirstContext (MonoBehaviour view, bool autoStartup) : base(view, autoStartup)
		{
		}
		
		protected override void mapBindings()
		{
			// EXAMPLE: MAPPING A SERVICE THAT MIGHT CHANGE.
			//We wrap the particular SDK inside an Adapter that suits OUR needs.

			injectionBinder.Bind<ISocialService>().To<FacebookService>().ToSingleton();

			//Our service can be bound to a different service (Like Google+)
			//injectionBinder.Bind<ISocialService>().To<GooglePlusService>().ToSingleton();

			//Or we can name the services and bind more than one
			//injectionBinder.Bind<ISocialService>().To<FacebookService>()
								//.ToSingleton()
								//.ToName(SocialServices.FACEBOOK);
			//injectionBinder.Bind<ISocialService>().To<GooglePlusService>()
								//.ToSingleton()
								//.ToName(SocialServices.GOOGLE_PLUS);

			//Or we can wrap it all into a master service
			//injectionBinder.Bind<ISocialService>().Bind<IMultiService>()
								//.To<MultiSocialService>().ToSingleton();







			// EXAMPLE: MAPPING A SERVICE YOU MIGHT WANT TO CUSTOMIZE

#if UNITY_EDITOR || UNITY_WEBPLAYER
			injectionBinder.Bind<IGameStore>().To<FakeGameStore>().ToSingleton();
#elif UNITY_IPHONE
			injectionBinder.Bind<IGameStore>().To<IosAppStore>().ToSingleton();
#elif UNITY_XBOX360
			injectionBinder.Bind<IGameStore>().To<XboxAppStore>().ToSingleton();
#endif







			// EXAMPLE: MAPPING A KNOWN QUANTITY
			//You know exactly the value you want to map

			injectionBinder.Bind<ISetupConfig> ().ToValue (SetupConfig.DEFAULTS);








			// EXAMPLE: FACTORY MAPPING
			//You want to create as many of these things as are ever asked for...

			injectionBinder.Bind<IEnemy> ().To<Borg> ();
			injectionBinder.Bind<IFeedData> ().To<FeedData> ();






			// EXAMPLE: USING ABSTRACT/PARENT CLASSESES
			//Sometimes an interface isn't convenient/possible

			injectionBinder.Bind<LevelModel> ().To<LevelOneModel> ();



			//Oh, and you can alter bindings on-the-fly
			injectionBinder.Unbind<LevelModel> ();
			injectionBinder.Bind<LevelModel> ().To<LevelTwoModel> ();




			// EXAMPLE: WRAPPING A MONOBEHAVIOUR
			//Why do this? Because we want to minimize dependencies...even on Unity!
			injectionBinder.Bind<IWebService> ().To<NetworkViewWebService> ();





			// EVENT/COMMAND BINDING
			//For communication around the app

			commandBinder.Bind(ExampleEvent.CHANGE_SOCIAL_SERVICE).To<SwitchServiceCommand>();
			commandBinder.Bind(ExampleEvent.POST_TO_FEED).To<PostToFeedCommand>();

			commandBinder.Bind(ExampleEvent.REQUEST_WEB_SERVICE).To<CallWebServiceCommand>();
			//The START event is fired as soon as mappings are complete.
			//Note how we've bound it "Once". This means that the mapping goes away as soon as the command fires.
			commandBinder.Bind(ContextEvent.START).To<StartCommand>().Once ();






			//VIEW/MEDIATION BINDING

			//This Binding instantiates a new ExampleMediator whenever as ExampleView
			//Fires its Awake method. The Mediator communicates to/from the View
			//and to/from the App. This keeps dependencies between the view and the app
			//separated.
			mediationBinder.Bind<ExampleView>().To<ExampleMediator>();


		}
	}
}

