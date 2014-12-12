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
		public 		SpriteUV	secondBackground;
		private	 	TextureInfo	textureInfo;
		private 	float		width;
		
		private		TextureInfo[] textures;
		//Public functions.
		public Background (Scene scene)
		{
			SetTextureArray ();
			
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
			textures[0] = new TextureInfo("/Application/textures/background(0%).png");	
			textures[1] = new TextureInfo("/Application/textures/background(-10%).png");
			textures[2]= new TextureInfo("/Application/textures/background(-20%).png");	
			textures[3]= new TextureInfo("/Application/textures/background(-30%).png");	
			textures[4]= new TextureInfo("/Application/textures/background(-40%).png");	
			textures[5]= new TextureInfo("/Application/textures/background(-50%).png");	
			textures[6]= new TextureInfo("/Application/textures/background(-60%).png");	
			textures[7]= new TextureInfo("/Application/textures/background(-70%).png");	
			textures[8]= new TextureInfo("/Application/textures/background(-80%).png");	
			textures[9]= new TextureInfo("/Application/textures/background(-90%).png");	
			textures[10]= new TextureInfo("/Application/textures/background(-100%).png");	
		}
		
		public void Update(Scene scene, int saturation)
		{
			saturation = Player.health;
			
			if (saturation == 0)		
			{
				textureInfo	= textures[0];
				
			}
			else if (saturation == -1)
			{
				textureInfo	= textures[1];
			}
			else if (saturation == -2)
			{
				textureInfo	= textures[2];
			}
			else if (saturation == -3)
			{
				textureInfo	= textures[3];
			}
			else if (saturation == -4)
			{
				textureInfo	= textures[4];
			}
			else if (saturation == -5)
			{
				textureInfo	= textures[5];
			}
			else if (saturation == -6)
			{
				textureInfo	= textures[6];
			}
			else if (saturation == -7)
			{
				textureInfo	= textures[7];
			}
			else if (saturation == -8)
			{
				textureInfo	= textures[8];
			}
			else if (saturation == -9)
			{
				textureInfo	= textures[9];
			}
			else if (saturation == -10)
			{
				textureInfo	= textures[10];
			}
		
		}
	
		public void Dispose()
		{
			textureInfo.Dispose();
		}
	}
}

