using System;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;


namespace MonochromeRainbow
{
	public class Bullet
	{
		private 	SpriteUV 	sprite;
		private	 	TextureInfo	textureInfo;
		public 		int 		bulletDirection;
		public 		Vector2		bulletPosition;
		
		public Bullet (Scene scene, Vector2 position, int direction)
		{
			bulletPosition = position;
			bulletDirection = direction;
			sprite	= new SpriteUV();
			
			textureInfo	= new TextureInfo("/Application/textures/bullet.png");
			
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
    		case 0:
				//Right
				xVelocity = 1.0f;
        	break;
    		case 1:
				//Up-Right
				xVelocity = 1.0f;
				yVelocity = 1.0f;
       		break;
			case 2:
				//Up
				yVelocity = 1.0f;
			break;
			case 3:
				//Up-Left
				xVelocity = -1.0f;
				yVelocity = 1.0f;
        	break;
 			default:
				//Left
				xVelocity = -1.0f;
        	break;
			}
			
			bulletPosition.Y += yVelocity;
			bulletPosition.X += xVelocity;
			sprite.Position = bulletPosition;
		}
		
		public void Draw()
		{
			
		}
		public void calculateMovement()
		{
			
		}
	}
}


