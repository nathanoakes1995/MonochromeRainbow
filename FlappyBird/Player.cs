using System;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace FlappyBird
{
	public class Player
	{
		private	static SpriteUV		player;
		private	static TextureInfo	textureInfo;
		private static GamePadData	gamePadData;
		
		private static int		health;
		private static bool		jumping;
		private static Vector2	playerPosition;
		
		private static float positionX, positionY;     
		private static float velocityX, velocityY;    
		private static float gravity = 0.5f;          
		private static float timeStep;           
		
		public Player (Scene scene, Vector2 playerPosition)
		{
			textureInfo		= new TextureInfo("/Application/textures/Player.png");
			
			player			= new SpriteUV(textureInfo);	
			player.Quad.S 	= textureInfo.TextureSizef;
			player.Position = playerPosition;
			
			health = 10;
			gravity = -10;
			jumping = false;
			
			scene.AddChild(player);
		}
		
		public static void Update (float elapsedTime)
		{
        	gamePadData = GamePad.GetData(0);
			
        	int speed = 4;
			
        	if ((gamePadData.Buttons & GamePadButtons.Left) != 0)
        	{
        		playerPosition.X -= speed;
        	}
        	if ((gamePadData.Buttons & GamePadButtons.Right) != 0)
        	{
        		playerPosition.X += speed;
        	}
        	if ((gamePadData.Buttons & GamePadButtons.Square) != 0)
        	{
        		//shoot;
        	}
        	if ((gamePadData.Buttons & GamePadButtons.Cross) != 0 && !jumping)
        	{
        		jumping = true;
				velocityY = -12.0f;
        	}
			
			if (dy > 5)
			{
        		dy = 5;
			}
			
            if (jumping) 
			{
				timeStep = elapsedTime;
			
							//https://wiki.allegro.cc/index.php?title=How_to_implement_jumping_in_platformers	
            	//velocityY += gravity 	* timeStep;
    			//positionX += velocityX 	* timeStep;
    			//positionY += velocityY 	* timeStep;
				
				positionY = positionY + (velocityY * timeStep) + (gravity * (timeStep ^ 2) / 2);
				velocityY = velocityY + (acceleration_y * timeStep);	
			}
			
			player.Position = playerPosition;
		}
	}
}

