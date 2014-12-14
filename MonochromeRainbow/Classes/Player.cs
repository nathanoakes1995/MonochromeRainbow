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
		public float			shootCoolTime;
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
		public Bullet[]			bullet;
		public bool[] 			bulletActive;
		public Vector2 			playerRec;
		public bool 			isPressed;
		public Vector2i[]		tileIndex;
		public bool 			aiming;
		public bool				canShoot;
		public bool isAlive;
		public Player (Scene scene, Vector2 playerPosition)
		{
			playerWidth = 32;
			playerHeight = 64;
			
			textureInfo		= new TextureInfo("/Application/textures/Player.png");
			SetTileIndex();
			timer = new Timer();
			previousTime = (float)timer.Milliseconds();
			
			player			= new SpriteTile(textureInfo);
			player.TileIndex2D = tileIndex[0];
			playerRec = new Vector2(32,64);
			player.Quad.S = playerRec;
			isAlive = true;
			playerPos = playerPosition;
			bounds = new Bounds2();
			health = 10;
			ammo = 50;
			mayJumpAgain = true;
			onGround = true;
			bulletActive = new bool[20];
			bullet = new Bullet[20];
			for (int i = 0; i < 20; i++)
			{
				bulletActive[i] = false;
				bullet[i] = new Bullet(scene, new Vector2(-100.0f,-100.0f),0); 
			}

			facingDirection = 0;
			aiming = false;
			canShoot = true;
			
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
			shootCoolTime += elapsedTime;
			
			
			if (!canBeHit)
				{
					if (coolTime >= 2000)
					{
						coolTime = 0.0f;
						canBeHit= true;
					}
				}
			if (!canShoot)
			{
				if (shootCoolTime >= 1000)
				{
					shootCoolTime = 0.0f;
					canShoot = true;
				}
			}
				
			if(health < 0)
			{
				health = 0;	
			}
			
			for (int i = 0; i < 20; i++)
			{
				if (bulletActive[i] == true)
				{
					bullet[i].Update();
					if(bullet[i].bulletPosition.X < -10 || bullet[i].bulletPosition.X > 970 || bullet[i].bulletPosition.Y < -10 || bullet[i].bulletPosition.Y > 554)
					{
						bullet[i].bulletPosition = new Vector2(-100.0f, -100.0f);
						bulletActive[i] = false;
					}
				}
			}			
			//Shooting.
        	if ((gamePadData.Buttons & GamePadButtons.Square) != 0)
        	{
        		//shoot;
				if (canShoot)
				{
					if (ammo > 0)
					{
						ammo --;
						bool bulletNotActive = false;
						int checkCount = 0;
						do
						{
							if (bulletActive[checkCount] == false)
							{
								bullet[checkCount].bulletDirection = facingDirection;
								bullet[checkCount].bulletPosition = new Vector2(playerPos.X + 28,playerPos.Y + 32);
								bulletActive[checkCount] = true;
								bulletNotActive = true;
								canShoot = false;
							}
							checkCount++;
						} while(bulletNotActive == false);

					}

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
			if(!isAlive)
			{
				AppMain.levelManager.SetLevel (8);	
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
				if ((gamePadData.Buttons & GamePadButtons.Left) != 0 & !((gamePadData.Buttons & GamePadButtons.Up) != 0))
        		{
					//Aim Left
					facingDirection = 4;
        		}
        		if ((gamePadData.Buttons & GamePadButtons.Right) != 0 & !((gamePadData.Buttons & GamePadButtons.Up) != 0))
        		{
					//Aim Right
					facingDirection = 0;
        		}
			}
					
			//Slow down player if button is held.
			if ((gamePadData.Buttons & GamePadButtons.Cross) != 0 & !onGround && yVelocity > 0)
			{
        		yVelocity += 0.1f;
			}
			
			//Check if player is off the ground.
			if (!onGround)
			{
				//Player loses vertical speed tue to gravity.
				yVelocity -= 0.5f;
			}

			//Player shouldn't fall too fast. [Terminal Velocity]
			if (yVelocity < -5.0f)
			{
        		yVelocity = -5.0f;
			}
			
			//Check if player is on the ground.
            if (yVelocity != 0.0f)
			{
				onGround = false;
    		}
			
			//Check if player has hit the ground.
			if (playerPos.Y < 0.0f)
			{
				playerPos.Y = 0.0f;
				onGround = true;
			}
						
			//Update player position.
    		playerPos.Y += yVelocity;
			playerPos.X += xVelocity;
			
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
			
			if(health == 0)	
			{
				//isAlive = false;
			}
		}
	}
}

