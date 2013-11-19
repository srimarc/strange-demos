using System;

namespace strange.examples.myfirstproject
{
	public class SetupConfig : ISetupConfig
	{

		public static ISetupConfig DEFAULTS = new SetupConfig(20, 0, 1);

		public int maxLevel{ get; set; }

		public int startLevel{ get; set; }

		public int difficulty{ get; set; }

		public SetupConfig(int maxLevel, int startLevel, int difficulty)
		{
			this.maxLevel = maxLevel;
			this.startLevel = startLevel;
			this.difficulty = difficulty;
		}

		public SetupConfig()
		{
		}
	}
}

