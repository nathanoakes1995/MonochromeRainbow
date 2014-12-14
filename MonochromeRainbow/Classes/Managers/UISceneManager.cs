using System;
using System.Collections.Generic;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;

using Sce.PlayStation.HighLevel.UI;

namespace MonochromeRainbow
{
    public class UISceneManager
	{
		public Sce.PlayStation.HighLevel.UI.Scene[] uiScenes;
		
        public UISceneManager()
        {
            Initialize();
			
			for(int i = 0; i < 5; i++)
			{
				uiScenes[i].RootWidget.AddChildLast(AppMain.panel);
				uiScenes[i].RootWidget.Visible = false;
				UISystem.SetScene(uiScenes[i]);
			}
        }

        public void Initialize ()
        {
            // Create scene
			uiScenes = new Sce.PlayStation.HighLevel.UI.Scene[5];
			uiScenes[0] = new Screen.MainMenu();
			uiScenes[1] = new Screen.Tutorial();
			uiScenes[2] = new Screen.Options();
			uiScenes[3] = new Screen.HighScores();
			uiScenes[4] = new Screen.Confirmation();
        }

        public void Update (Scene scene)
        {
            // Query gamepad for current state
            var gamePadData = GamePad.GetData (0);

            // Query touch for current state
            List<TouchData> touchDataList = Touch.GetData (0);

            // Update UI Toolkit
            UISystem.Update(touchDataList);
        }
    }
}