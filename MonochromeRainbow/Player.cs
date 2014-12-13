using System;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace MonochromeRainbow
{
	public class Player
	{
		private	TextureInfo	textureInfo;
		private GamePadData	gamePadData;
		
		public int		health;
		public int		level;
		public float	xVelocity;
		public float	yVelocity;
		public bool		mayJumpAgain;
		public bool		onGround;
		public Bounds2 	bounds;
		public Vector2	playerPos; 
		public SpriteUV	player;
		
		public Player (Scene scene, Vector2 playerPosition)
		{
			textureInfo		= new TextureInfo("/Application/textures/Player.png");
			
			player			= new SpriteUV(textureInfo);	
			player.Quad.S 	= textureInfo.TextureSizef;
			playerPos = playerPosition;
			bounds = new Bounds2();
			health = 10;
			mayJumpAgain = true;
			onGround = true;
			
			scene.AddChild(player);
		}
		
		public int GetHealth()
		{
			return health;	
		}
		
		public int ReturnLevel()
		{
			return level;
		}
		
		public void Update(int level)
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
			
			if ((gamePadData.Buttons & GamePadButtons.Start) != 0 && level == 0)
			{
				level = 1;
			}
			
			//Check if player is off the ground.
			if (!onGround)
			{
				//Player loses vertical speed tue to gravity.
				yVelocity -= 0.5f;
			}
			
			//Slow down player if button is held.
			if ((gamePadData.Buttons & GamePadButtons.Cross) != 0 & !onGround && yVelocity > 0)
			{
        		yVelocity += 0.1f;
			}
			
			//Player shouldn't fall too fast. [Terminal Velocity]
			if (yVelocity < -5.0f)
			{
        		yVelocity = -5.0f;
			}
			
			//Update player position.
    		playerPos.Y += yVelocity;
			playerPos.X += xVelocity;
			
			//Check if player is on the ground.
            if (playerPos.Y != 0)
			{
				onGround = false;
    		}
			
			//Check if player has hit the ground.
			if (playerPos.Y < 0.0f)
			{
				playerPos.Y = 0.0f;
				onGround = true;
			}
			
			//Check if player has hit the wall.
			if (playerPos.X > Director.Instance.GL.Context.GetViewport().Width - player.Quad.S.X)
			{
				playerPos.X = Director.Instance.GL.Context.GetViewport().Width - player.Quad.S.X;
			}
			else if (playerPos.X < 0.0f)
			{
				playerPos.X = 0.0f;
			}
			
			player.Position = playerPos;
		}
	}
}

