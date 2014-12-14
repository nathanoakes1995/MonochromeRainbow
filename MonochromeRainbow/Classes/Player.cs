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
		private	TextureInfo		textureInfo;
		private GamePadData		gamePadData;
		public bool 			canBeHit;
		public int				health;
		public Timer			timer;
		public float			previousTime; 
		public float			currentTime;
		public float			elapsedTime;
		public float			coolTime;
		public int 				ammo;
		public int 				facingDirection;
		public int				playerWidth;
		public int				playerHeight;
		public float			xVelocity;
		public float			yVelocity;
		public bool				mayJumpAgain;
		public bool				onGround;
		public bool				startOn;
		public Bounds2 			bounds;
		public Vector2			playerPos; 
		public SpriteTile			player;
		public Bullet			bullet;
		public bool 			bulletActive;
		public Vector2 			playerRec;
		public bool 			isPressed;
		public Vector2i[]		tileIndex;
		public bool 			aiming;
		
		public Player (Scene scene, Vector2 playerPosition)
		{
			playerWidth = 32;
			playerHeight = 64;
			
			textureInfo		= new TextureInfo("/Application/textures/playerSheet.png");
			SetTileIndex();
			timer = new Timer();
			previousTime = (float)timer.Milliseconds();
			player			= new SpriteTile(textureInfo,tileIndex[0]); 
			playerRec = new Vector2(32,64);
			player.Quad.S = playerRec;
			playerPos = playerPosition;
			bounds = new Bounds2();
			health = 10;
			ammo = 50;
			mayJumpAgain = true;
			onGround = true;
			bulletActive = false;
			facingDirection = 0;
			aiming = false;
			
			scene.AddChild(player);
		}

		public void SetTileIndex()
		{
			int x = playerWidth;
			int y = playerHeight;
			
			tileIndex = new Vector2i[3];
			tileIndex[0]	= new Vector2i(0,0);
			tileIndex[1]	= new Vector2i(0,0);
			tileIndex[2]	= new Vector2i(0,0);
		}
		
		public void Update(Scene gameScene)
		{
        	//Get gamepad input.
			gamePadData = GamePad.GetData(0);
			currentTime = (float)timer.Milliseconds();
			elapsedTime = currentTime - previousTime;
			previousTime = currentTime;
			coolTime+= elapsedTime;
			
			
			if (!canBeHit)
				{
					if (coolTime >= 2000)
					{
						coolTime = 0.0f;
						canBeHit= true;
					}
				}
				
			if(health < 0)
			{
				health = 0;	
			}
			
			if (bulletActive)
			{
				//for (int i = 0; i < bulletCount; i++)
				//{
//					bullet[i].Update();
//					if(bullet[i].bulletPosition.X < 0 || bullet[i].bulletPosition.X > 960)
//					{
//						bullet[i].delete(gameScene);
//						bullet[i] = null;
//					}
					bullet.Update();
					if(bullet.bulletPosition.X < 0 || bullet.bulletPosition.X > 960)
					{
						bullet.delete(gameScene);
						bullet = null;
						bulletActive = false;
					}
				//}
			}

			
			//Shooting.
        	if ((gamePadData.Buttons & GamePadButtons.Square) != 0)
        	{
        		//shoot;
				//Create a bullet
				if (ammo > 0)
				{
					ammo --;
					Console.WriteLine(ammo);
					//bullet[bulletCount] = new Bullet(gameScene, new Vector2(playerPos.X + 28,playerPos.Y + 32), 0);
					bullet = new Bullet(gameScene, new Vector2(playerPos.X + 28,playerPos.Y + 32), facingDirection);
					bulletActive = true;
//					bulletCount++;
//					if (bulletCount > 19)
//					{
//						bulletCount = 0;	
//					}
				}
        	}
			
			//Check if player is on ground.
        	if (onGround)
			{
        		yVelocity = 0;
				
				xVelocity *= 0.9f;
				
				//Apply friction.
        		if ((gamePadData.Buttons & GamePadButtons.Left) == 0)
				{
					xVelocity *= 0.65f;
        		}
				
				//Check if cross is pressed.
				if ((gamePadData.Buttons & GamePadButtons.Cross) != 0)
				{
            		//Check if player is able to jump.
					if (mayJumpAgain)
					{
                		yVelocity = 11.0f;
                		mayJumpAgain = false;
					}
        		}
        		else
				{
					mayJumpAgain = true;
        		}
        	}	
			
			if ((gamePadData.Buttons & GamePadButtons.Start) != 0 && !isPressed)
        	{
				AppMain.levelManager.SetLevel(7);
				isPressed = true;
				System.Threading.Thread.Sleep(100);
        	} 
			if ((gamePadData.Buttons & GamePadButtons.Start) == 0)
        	{
				isPressed = false;
        	}				
			
			//Left movement.
			if (!aiming)
			{
        		if ((gamePadData.Buttons & GamePadButtons.Left) != 0)
        		{
					xVelocity = -4.0f;
					//Aim Left
					facingDirection = 4;
        		}
			
				//Right movement.
        		if ((gamePadData.Buttons & GamePadButtons.Right) != 0)
        		{
					xVelocity = 4.0f;
					//Aim Right
					facingDirection = 0;
        		}
			}
			if ((gamePadData.Buttons & GamePadButtons.R) != 0)
			{
				//Stop moving to aim
				aiming = true;
			}
			
			if (aiming)
			{
				if ((gamePadData.Buttons & GamePadButtons.R) == 0)
				{
					//Stop aiming
					aiming = false;
				}
				if ((gamePadData.Buttons & GamePadButtons.Up) != 0)
				{
					//Aim up
					facingDirection = 2;
				}
				if (((gamePadData.Buttons & GamePadButtons.Up) != 0) & ((gamePadData.Buttons & GamePadButtons.Right) != 0))
				{
					//Aim up-right
					facingDirection = 1;
				}
				if (((gamePadData.Buttons & GamePadButtons.Up) != 0) & ((gamePadData.Buttons & GamePadButtons.Left) != 0))
				{
					//Aim up-left
					facingDirection = 3;
				}
				if ((gamePadData.Buttons & GamePadButtons.Left) != 0)
        		{
					//Aim Left
					facingDirection = 4;
        		}
        		if ((gamePadData.Buttons & GamePadButtons.Right) != 0)
        		{
					//Aim Right
					facingDirection = 0;
        		}
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
            if (yVelocity != -5.0f)
			{
				onGround = false;
    		}
			
			//Check if player has hit the ground.
			if (playerPos.Y < 0.0f)
			{
				playerPos.Y = -5.0f;
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

