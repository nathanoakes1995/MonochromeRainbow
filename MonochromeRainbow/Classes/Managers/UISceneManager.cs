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
        }

        public void Initialize ()
        {
            // Create scene
			uiScenes = new Sce.PlayStation.HighLevel.UI.Scene[6];
			uiScenes[0] = new Sce.PlayStation.HighLevel.UI.Scene();
			uiScenes[1] = new Screen.MainMenu();
			uiScenes[2] = new Screen.Tutorial();
			uiScenes[3] = new Screen.Options();
			uiScenes[4] = new Screen.HighScores();
			uiScenes[5] = new Screen.Confirmation();
        }

        public void Update ()
        {
            // Query gamepad for current state
            var gamePadData = GamePad.GetData (0);

            // Query touch for current state
            List<TouchData> touchDataList = Touch.GetData (0);

            // Update UI Toolkit
            UISystem.Update(touchDataList);
        }

        public void Render ()
        {
        }
    }
}