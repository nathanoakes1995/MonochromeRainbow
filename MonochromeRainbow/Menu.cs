using System;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;
using System.Threading;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace MonochromeRainbow
{
	public class Menu
	{
		private	TextureInfo	textureInfo;
		private SpriteUV sprite;
		public Button newGame;
		
		public Menu (Scene scene, int level)
		{
			textureInfo = new TextureInfo("Application/textures/MenuScreen.png");
			sprite = new SpriteUV(textureInfo);
			sprite.Quad.S = textureInfo.TextureSizef;
			scene.AddChild (sprite);
			
			LoadMenus (level, scene);
		}
		
		public void LoadMenus(int level, Scene scene)
		{
			if(level == 0)
			{
				newGame = new Button(scene, "/Application/textures/Buttons/NewGame.png", new Vector2(380, 242));
			}
		}
		
		public void Update(int level)
		{
			foreach (var touchData in Touch.GetData (0))
			{
				if(touchData.Status == TouchStatus.Down)
				{
					Bounds2 tempBounds = new Bounds2();
					tempBounds.Min = new Vector2((touchData.X - 1), (touchData.Y -1));
					tempBounds.Max = new Vector2((touchData.X + 1), (touchData.Y + 1));
					
					if( tempBounds.Overlaps (newGame.bounds))
					{
						//AppMain.levelManager.level = 1;	
					}
					
					
				}	
			}
		}
	}
}

