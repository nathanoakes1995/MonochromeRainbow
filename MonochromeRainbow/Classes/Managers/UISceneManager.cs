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
        private GraphicsContext graphics;

        public UISceneManager()
        {
            Initialize();

            while (true)
			{
                SystemEvents.CheckEvents();
                Update ();
                Render ();
            }
        }

        public void Initialize ()
        {
            // Set up the graphics system
            graphics = new GraphicsContext ();

            // Initialize UI Toolkit
            UISystem.Initialize(graphics);

            // Create scene
			Sce.PlayStation.HighLevel.UI.Scene[] uiScenes;
			uiScenes = new Sce.PlayStation.HighLevel.UI.Scene[5];
			uiScenes[0] = new Screen.MainMenu();
			uiScenes[1] = new Screen.Tutorial();
			uiScenes[2] = new Screen.Options();
			uiScenes[3] = new Screen.HighScores();
			uiScenes[4] = new Screen.Confirmation();
			
			// Set scene
			UISystem.SetScene(uiScenes[4], null);
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
            // Clear the screen
			graphics.SetClearColor (1.0f, 1.0f, 1.0f, 1.0f);
			graphics.Clear ();

            // Render UI Toolkit
            UISystem.Render ();

            // Present the screen
            graphics.SwapBuffers ();
        }
    }
}