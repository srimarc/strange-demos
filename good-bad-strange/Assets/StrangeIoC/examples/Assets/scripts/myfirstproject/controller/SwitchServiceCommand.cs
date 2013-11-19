using System;
using strange.extensions.command.impl;
using strange.examples.service;

namespace strange.examples.myfirstproject
{
	public class SwitchServiceCommand : EventCommand
	{
		[Inject]
		public IMultiService service{ get; set; }


		public override void Execute ()
		{
			Enum e = evt.data as Enum;
			service.selectService (e);
		}
	}
}

