using System;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;


namespace MonochromeRainbow
{
	public class Bullet
	{
		public 	SpriteUV 	sprite;
		private	 	TextureInfo	textureInfo;
		public 		int 		bulletDirection;
		public 		Vector2		bulletPosition;
				public Bounds2		bounds;
		
		public Bullet (Scene scene, Vector2 position, int direction)
		{
			bulletPosition = position;
			bulletDirection = direction;
			sprite	= new SpriteUV();
			
			textureInfo	= new TextureInfo("/Application/textures/other/bullet.png");
			
			sprite			= new SpriteUV(textureInfo);
			sprite.Quad.S	= textureInfo.TextureSizef;
			sprite.Position = position;
			
			scene.AddChild(sprite);
		}
				
		public void Update()
		{
			float xVelocity = 0.0f;
			float yVelocity = 0.0f;
			switch (bulletDirection)
			{
    		case 4:
				//Right
				xVelocity = 5.0f;
        	break;
    		case 3:
				//Up-Right
				xVelocity = 5.0f;
				yVelocity = 5.0f;
       		break;
			case 2:
				//Up
				yVelocity = 5.0f;
			break;
			case 1:
				//Up-Left
				xVelocity = -5.0f;
				yVelocity = 5.0f;
        	break;
 			default:
				//Left
				xVelocity = -5.0f;
        	break;
			}
			
			bulletPosition.Y += yVelocity;
			bulletPosition.X += xVelocity;
			sprite.Position = bulletPosition;
		}
		
		public void delete(Scene scene)
		{
			scene.RemoveChild(sprite, true);
		}
	}
}


