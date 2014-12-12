using System;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace FlappyBird
{
	public class Background
	{	
		//Private variables.
		private 	SpriteUV 	background;
		private	 	TextureInfo	textureInfo;
		private 	float		width;
		private		int			saturation;

		//Public functions.
		public Background (Scene scene)
		{
			background	= new SpriteUV();
			
			textureInfo	= new TextureInfo("/Application/textures/background(0%).png");
			
			background			= new SpriteUV(textureInfo);
			background.Quad.S	= textureInfo.TextureSizef;
			
			//Get background bounds.
			Bounds2 b = background.Quad.Bounds2();
			width     = b.Point10.X;
			
			saturation = Player.health;
			
			//Add to the current scene.
			scene.AddChild(background);
		}	
		
		//public void Update()
		//{
			//if (saturation == 0)		
			//{
				//textureInfo	= new TextureInfo("/Application/textures/background(0%).png");
			//}
			//else if (saturation == -1)
			//{
			//	textureInfo	= new TextureInfo("/Application/textures/background(-10%).png");
			//}
			//else if (saturation == -2)
			//{
			//	textureInfo	= new TextureInfo("/Application/textures/background(-20%).png");
			//}
			//else if (saturation == -3)
			//{
			//	textureInfo	= new TextureInfo("/Application/textures/background(-30%).png");
			//}
			//else if (saturation == -4)
			//{
			//	textureInfo	= new TextureInfo("/Application/textures/background(-40%).png");
			//}
			//else if (saturation == -5)
			//{
			//	textureInfo	= new TextureInfo("/Application/textures/background(-50%).png");
			//}
			//else if (saturation == -6)
			//{
			//	textureInfo	= new TextureInfo("/Application/textures/background(-60%).png");
			//}
			//else if (saturation == -7)
			//{
			//	textureInfo	= new TextureInfo("/Application/textures/background(-70%).png");
			//}
			//else if (saturation == -8)
			//{
			//	textureInfo	= new TextureInfo("/Application/textures/background(-80%).png");
			//}
			//else if (saturation == -9)
			//{
			//	textureInfo	= new TextureInfo("/Application/textures/background(-90%).png");
			//}
			//else if (saturation == -10)
			//{
			//	textureInfo	= new TextureInfo("/Application/textures/background(-100%).png");
			//}
		//}
	
		public void Dispose()
		{
			textureInfo.Dispose();
		}
	}
}

