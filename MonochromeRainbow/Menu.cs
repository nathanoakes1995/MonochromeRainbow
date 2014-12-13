using System;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace MonochromeRainbow
{
	public class Menu
	{
		private	TextureInfo	textureInfo;
		private SpriteUV sprite;
		private GamePadData	gamePadData;
		public Button buttons;
		
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
				Button NewGame = new Button(scene, "/Application/textures/Buttons/NewGame.png", new Vector2(380, 242));
			}
		}
		
		public void Update(int level)
		{
			gamePadData = GamePad.GetData(0);
			
		}
	}
}

