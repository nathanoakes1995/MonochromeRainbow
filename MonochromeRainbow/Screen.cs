using System;
using System.Threading;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;
using Sce.PlayStation.Core.Environment;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace MonochromeRainbow
{
	public class Screen
	{
		private TextureInfo		textureInfo;
		private TextureInfo[]	textures;
		
		private SpriteUV	screen;
		
		public Screen (Scene scene, int level)
		{
			SetScreenArray();
			
			textureInfo	= textures[0];
			
			screen = new SpriteUV(textureInfo);
			screen.Quad.S = textureInfo.TextureSizef;
			
			scene.AddChild(screen);
		}
		
		public void SetScreenArray()
		{
			textures = new TextureInfo[5];
			textures[0]		= new TextureInfo("/Application/textures/MenuScreen.png");
			textures[1]		= new TextureInfo("/Application/textures/MenuScreen.png");
			textures[2]		= new TextureInfo("/Application/textures/MenuScreen.png");
			textures[3]		= new TextureInfo("/Application/textures/MenuScreen.png");	
			textures[4]		= new TextureInfo("/Application/textures/MenuScreen.png");	
		}
		
		public void LoadScreens(Scene scene, int level)
		{
			if(level == 5)
			{
				scene.RemoveChild(screen, true);
				//AppMain.mainMenu = new MainMenu();
			}
		}
	}
}

