using System;

namespace strange.examples.myfirstproject
{
	public interface ISetupConfig
	{
		int maxLevel{ get; set; }

		int startLevel{ get; set; }

		int difficulty{ get; set; }
	}
}

