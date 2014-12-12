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
		public Bounds2 bounds;
		private static int		health;
		private static float	xVelocity;
		private static float	yVelocity;
		private static bool		mayJumpAgain;
		private static bool		onGround;
		private static Vector2	playerPosition;         
		
		public Player (Scene scene, Vector2 playerPosition)
		{
			textureInfo		= new TextureInfo("/Application/textures/Player.png");
			
			player			= new SpriteUV(textureInfo);	
			player.Quad.S 	= textureInfo.TextureSizef;
			player.Position = playerPosition;
			bounds = new Bounds2();
			health = 10;
			mayJumpAgain = true;
			onGround = true;
			
			scene.AddChild(player);
		}
		
		public static void Update (float elapsedTime)
		{
        	//Get gamepad input.
			gamePadData = GamePad.GetData(0);

			//Shooting.
        	if ((gamePadData.Buttons & GamePadButtons.Square) != 0)
        	{
        		//shoot;
        	}
			
			//Check if player is on ground.
        	if (onGround)
			{
        		//Apply friction.
        		xVelocity *= 0.9f;
				
				//Check if cross is pressed.
				if ((gamePadData.Buttons & GamePadButtons.Cross) != 0)
				{
            		//Check if player is able to jump.
					if (mayJumpAgain)
					{
                		yVelocity = 10.0f;
                		mayJumpAgain = false;
						
						Console.Write (yVelocity);
					}
        		}
        		else
				{
					mayJumpAgain = true;
        		}
        	}	
			
			//Left movement.
        	if ((gamePadData.Buttons & GamePadButtons.Left) != 0)
        	{
        		xVelocity = -3.0f;
        	}
			
			//Right movement.
        	if ((gamePadData.Buttons & GamePadButtons.Right) != 0)
        	{
        		xVelocity = 3.0f;
        	}
			
			//Check if player is off the ground.
			if (!onGround)
			{
				//Player loses vertical speed tue to gravity.
				yVelocity -= 0.5f;
			}
			
			//Slow down player if button is held.
			if ((gamePadData.Buttons & GamePadButtons.Cross) != 0 && !onGround && yVelocity > 0)
			{
        		yVelocity += 0.1f;
			}
			
			//Player shouldn't fall too fast. [Terminal Velocity]
			if (yVelocity < -5.0f)
			{
        		yVelocity = -5.0f;
			}
			
			//Update player position.
    		playerPosition.Y += yVelocity;
			playerPosition.X += xVelocity;
			
			//Check if player is on the ground.
            if (playerPosition.Y != 0)
			{
				onGround = false;
    		}
			
			//Check if player has hit the ground.
			if (playerPosition.Y < 0.0f)
			{
				playerPosition.Y = 0.0f;
				onGround = true;
			}
			
			//Check if player has hit the wall.
			if (playerPosition.X > Director.Instance.GL.Context.GetViewport().Width - player.Quad.S.X)
			{
				playerPosition.X = Director.Instance.GL.Context.GetViewport().Width - player.Quad.S.X;
			}
			else if (playerPosition.X < 0.0f)
			{
				playerPosition.X = 0.0f;
			}
			
			player.Position = playerPosition;
		}
	}
}

