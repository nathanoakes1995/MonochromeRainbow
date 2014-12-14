using System;

using Sce.PlayStation.Core;

namespace MonochromeRainbow
{
	public class LevelManager
	{	
		public int	level;
		public int	changeTo;
		
		/*
		LEVEL 0 = MENU SCREEN
		LEVEL 1 = TUTORIAL SCREEN
		LEVEL 2 = OPTIONS SCREEN
		LEVEL 3 = HIGH SCORES SCREEN
		LEVEL 4 = CONFIRMATION SCREEN
		LEVEL 5 = GAME LEVEL ALPHA
		LEVEL 6 = GAME LEVEL BETA
		LEVEL 7 = GAME OVER SCREEN
		*/
		
		public LevelManager()
		{				
			level = 0;
		}
		
		public void SetLevel(int changeTo)
		{
			level = changeTo;
			
			AppMain.audioManager.SetBGM(level);
			AppMain.audioManager.PlayBGM();
		}
	}
}

