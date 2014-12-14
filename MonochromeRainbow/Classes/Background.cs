using System;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace MonochromeRainbow
{
	public class Background
	{	
		private TextureInfo		textureInfo;
		private TextureInfo[]	textures;
		
		public int		level;
		public float	width;
		
		public SpriteUV background;
		public SpriteUV	secondBackground;
		
		//Public functions.
		public Background (Scene scene)
		{
			SetTextureArray();
			
			textureInfo = new TextureInfo();
			textureInfo = textures[0];
			
			//textureInfo = new TextureInfo("/Application/textures/background(0%).png");	
			
			background			= new SpriteUV(textureInfo);
			background.Quad.S	= textureInfo.TextureSizef;
			
			//Get background bounds.
			Bounds2 b = background.Quad.Bounds2();
			width     = b.Point10.X;
			
			//Add to the current scene.
			scene.AddChild(background);
		}	
		
		public void SetTextureArray()
		{
			textures = new TextureInfo[11];
			textures[0]		= new TextureInfo("/Application/textures/background/levelBackground(-100%).png");
			textures[1]		= new TextureInfo("/Application/textures/background/levelBackground(-90%).png");
			textures[2]		= new TextureInfo("/Application/textures/background/levelBackground(-80%).png");	
			textures[3]		= new TextureInfo("/Application/textures/background/levelBackground(-70%).png");	
			textures[4]		= new TextureInfo("/Application/textures/background/levelBackground(-60%).png");	
			textures[5]		= new TextureInfo("/Application/textures/background/levelBackground(-50%).png");
			textures[6]		= new TextureInfo("/Application/textures/background/levelBackground(-40%).png");	
			textures[7]		= new TextureInfo("/Application/textures/background/levelBackground(-30%).png");	
			textures[8]		= new TextureInfo("/Application/textures/background/levelBackground(-20%).png");	
			textures[9]		= new TextureInfo("/Application/textures/background/levelBackground(-10%).png");	
			textures[10]	= new TextureInfo("/Application/textures/background/levelBackground(0%).png");
		}
		
		public void Update(Scene scene, int saturation, int level)
		{
			if(level == 4 || level == 5)
			{	
				textureInfo	= textures[saturation];
			
				background.TextureInfo = textureInfo;
				background.Draw();
			}
		}
	
		public void Dispose()
		{
			textureInfo.Dispose();
		}
	}
}

