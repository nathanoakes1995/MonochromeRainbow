//implementing scenes
//if count = 1,2 or 3
//why ~main

using System;
using System.Collections.Generic;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;
using Sce.PlayStation.HighLevel.UI;
	
namespace MonochromeRainbow
{
	public class AppMain
	{
		private static Sce.PlayStation.HighLevel.UI.Label				scoreLabel;
		private static Sce.PlayStation.HighLevel.UI.Label				healthLabel;
		private static Sce.PlayStation.HighLevel.UI.Label				ammoLabel;
		private static Sce.PlayStation.HighLevel.UI.Label				multiplierLabel;
		private static Sce.PlayStation.HighLevel.UI.Label				rainbowLabel;
		
		public static Sce.PlayStation.HighLevel.GameEngine2D.Scene 		gameScene;
		public static Sce.PlayStation.HighLevel.UI.Scene 				uiScene;
		
		public static float enemyPreviousTime; 
		public static float enemyCurrentTime;
		public static float enemyElapsedTime;
		public static float enemyCoolTime;
		public static int	specMoveProg;
		public static int	score;
		public static int	multiplier;
		public static int	playerHealth;
		public static int	level;
		public static float	previousTime; 
		public static float	currentTime;
		public static float	elapsedTime;
		public static float	accumulatedDeltaTime;
		public static bool	collectibleActive;
		public static bool 	enemyCanBeSpawned;
		public static bool	isPressed;
		public static bool	justDied;
		public static bool	quitGame;
		public static bool	gameStart;
		
		public static GamePadData		gamePadData;
		public static Background		background;
		public static AudioManager		audioManager;
		public static LevelManager		levelManager;
		//public static UISceneManager	uiSceneManager;
		public static Collectibles		collectible;
		public static Platform[]		platforms;	
		public static Panel				panel;
		public static Timer				timer;
		public static Timer 			enemyTimer = new Timer();
		
		public static Player		player;
		public static Enemy[]		enemy;
			
		public static void Main (string[] args)
		{					
			timer = new Timer();
			previousTime = (float)timer.Milliseconds();
			
			Initialize();
			
			//Game loop
			quitGame = false;
			while (!quitGame) 
			{
				Update();
				
				Director.Instance.Update();
				Director.Instance.Render();
				UISystem.Render();
				
				Director.Instance.GL.Context.SwapBuffers();
				Director.Instance.PostSwap();
			}
			
			background.Dispose();
			
			Director.Terminate();
		}

		public static void Initialize ()
		{
			//Set up director and UISystem.
			Director.Initialize ();
			UISystem.Initialize(Director.Instance.GL.Context);
			
			//Set game scene
			gameScene = new Sce.PlayStation.HighLevel.GameEngine2D.Scene();
			gameScene.Camera.SetViewFromViewport();
			
			//Set the ui scene.
			uiScene = new Sce.PlayStation.HighLevel.UI.Scene();
			Panel panel  = new Panel();
			panel.Width  = Director.Instance.GL.Context.GetViewport().Width;
			panel.Height = Director.Instance.GL.Context.GetViewport().Height;
			
			//Health label data
			healthLabel = new Sce.PlayStation.HighLevel.UI.Label();
			healthLabel.HorizontalAlignment = HorizontalAlignment.Center;
			healthLabel.VerticalAlignment = VerticalAlignment.Top;
			healthLabel.SetPosition(
				Director.Instance.GL.Context.GetViewport().Width/2 - healthLabel.Width/2,
				Director.Instance.GL.Context.GetViewport().Height*0.1f - healthLabel.Height/2);
			panel.AddChildLast(healthLabel);
			//Ammo label data
			ammoLabel = new Sce.PlayStation.HighLevel.UI.Label();
			ammoLabel.HorizontalAlignment = HorizontalAlignment.Left;
			ammoLabel.VerticalAlignment = VerticalAlignment.Top;
			ammoLabel.SetPosition(
				200 - ammoLabel.Width/2,
				Director.Instance.GL.Context.GetViewport().Height*0.1f - ammoLabel.Height/2);
			panel.AddChildLast(ammoLabel);
			//Multiplier lable data
			multiplierLabel = new Sce.PlayStation.HighLevel.UI.Label();
			multiplierLabel.HorizontalAlignment = HorizontalAlignment.Right;
			multiplierLabel.VerticalAlignment = VerticalAlignment.Top;
			multiplierLabel.SetPosition(
				Director.Instance.GL.Context.GetViewport().Width - 200 - multiplierLabel.Width/2,
				Director.Instance.GL.Context.GetViewport().Height*0.1f - multiplierLabel.Height/2 + 20);
			panel.AddChildLast(multiplierLabel);
			//Score label data
			scoreLabel = new Sce.PlayStation.HighLevel.UI.Label();
			scoreLabel.HorizontalAlignment = HorizontalAlignment.Right;
			scoreLabel.VerticalAlignment = VerticalAlignment.Top;
			scoreLabel.SetPosition(
				Director.Instance.GL.Context.GetViewport().Width - 200 - scoreLabel.Width/2,
				Director.Instance.GL.Context.GetViewport().Height*0.1f - scoreLabel.Height/2);
			panel.AddChildLast(scoreLabel);
			//Rainbow label data
			rainbowLabel = new Sce.PlayStation.HighLevel.UI.Label();
			rainbowLabel.HorizontalAlignment = HorizontalAlignment.Right;
			rainbowLabel.VerticalAlignment = VerticalAlignment.Top;
			rainbowLabel.SetPosition(
				90 - rainbowLabel.Width/2,
				Director.Instance.GL.Context.GetViewport().Height*0.1f - rainbowLabel.Height/2 + 20);
			panel.AddChildLast(rainbowLabel);
				
			uiScene.RootWidget.AddChildLast(panel);
			UISystem.SetScene(uiScene);

			enemy = new Enemy[20];
			
			score = 0;
			multiplier = 1;
			justDied = true;
			gameStart = false;
			
			LoadLevel();
			
			audioManager.SetBGM(level);
			
			//Run the scene.
			Director.Instance.RunWithScene(gameScene, true);
		}
		
		public static void Update()
		{
			level = levelManager.level;
			
			currentTime = (float)timer.Milliseconds();
			elapsedTime = currentTime - previousTime;
			previousTime = currentTime;

			accumulatedDeltaTime += elapsedTime;
			
			//Get gamepad input.
			gamePadData = GamePad.GetData(0);
			
			
			if(level == 0)
			{
				background.Update(gameScene, 10, levelManager.level);
				
				if ((gamePadData.Buttons & GamePadButtons.Start) != 0 && !isPressed)
        		{
					AppMain.levelManager.SetLevel(5);
					isPressed = true;	
					gameStart = true;
					
					LoadLevel();
        		} 
			}
			
			if(level == 5 || level == 6)
			{

				//Collectible update
				if (collectibleActive)
				{
					collectible.Update();
				}
				
				score += 1 * multiplier;
				scoreLabel.Text = "" + score;
				ammoLabel.Text = "Ammo: " + player.ammo;
				multiplierLabel.Text = "Multiplier: x" + multiplier;
				
				if (!collectibleActive)
				{
					if (accumulatedDeltaTime >= 20000)
					{
						//Create a collectible
						collectible = new Collectibles(gameScene, specMoveProg);
						collectibleActive = true;
						accumulatedDeltaTime = 0.0f;
					}
				}
				else
				{
					if (accumulatedDeltaTime >= 10000)
					{
						//Delete collectible
						collectible.delete(gameScene);
						collectible = null; 
						collectibleActive = false;
						accumulatedDeltaTime = 0.0f;
					}
				}
				
				//Player update
				player.Update(gameScene);
				int health = player.health;
				
				//Background update
				background.Update(gameScene, health, levelManager.level);
				
				//Update EnemyAI
				for(int i = 0; i < 10; i++)
				{
					//checks to see if enemy is alive
					if(enemy[i].isAlive)
					{	
						//runs AI for living enemy
						enemy[i].RunAI (player.playerPos);
						enemy[i].Update ();
					}
					else
					{	
						//respawns a dead one
						SpawnEnemy (i);
					}
				}
				
				Console.WriteLine (enemy[4].position.X);
				
				healthLabel.Text = "Health: " + player.health;
				CheckCollision();
			}
			
			if(level == 7)
			{
				if ((gamePadData.Buttons & GamePadButtons.Start) != 0 && !isPressed)
        		{
					AppMain.levelManager.SetLevel(5);
					isPressed = true;	
					System.Threading.Thread.Sleep(100);
        		} 
				if ((gamePadData.Buttons & GamePadButtons.Start) == 0)
        		{		
					isPressed = false;
        		}		
			}
			
			if (level == 8)
			{
				if(justDied)
				{
					AppMain.audioManager.SetSFX(3);
					System.Threading.Thread.Sleep(1000);
					AppMain.audioManager.SetSFX(4);
					System.Threading.Thread.Sleep(2500);
					AppMain.audioManager.SetBGM(level);	
					justDied = false;
				}
				
				if (!background.stop)
				{
					background.Update(gameScene, 0, level);
				}
				else
				{
					System.Threading.Thread.Sleep(5000);
						
					quitGame = true;
				}

			}
		}
		
		public static void SpawnEnemy(int whichEnemy)
		{		
			//for spawning a new enemy if one is dead.
			enemy[whichEnemy].isAlive = true;
			enemy[whichEnemy].Load (gameScene);				
		}
		
		public static void CheckCollision()
		{
			for(int i = 0; i < 10; i++)
			{
				if(enemy[i].isAlive)
				{
					for(int k = 0; k < 9; k++)
					{
						if (player.enemyBulletCollision(enemy[i],gameScene))
						{
							enemy[i].isAlive = false;	
						}
						enemy[i].sprite.GetContentWorldBounds(ref enemy[i].bounds);	
						platforms[k].sprite.GetContentWorldBounds (ref platforms[k].bounds);
						
						if(enemy[i].yVelocity < 0)
						{
							if(enemy[i].bounds.Overlaps(platforms[k].bounds))
							{		
								if(enemy[i].position.Y > (platforms[k].position.Y + (platforms[k].platformHeight / 2)))
								{
									enemy[i].position.Y = (platforms[k].position.Y + platforms[k].platformHeight);
									enemy[i].sprite.Position = enemy[i].position;
									enemy[i].onGround = true;
								}
							}
							
							if(!enemy[i].bounds.Overlaps(platforms[k].bounds) && enemy[i].position.Y != 0.0f)
							{
								enemy[i].onGround = false;
							}	
						}
					}
				
					player.player.GetContentWorldBounds (ref player.bounds);
					
					if(enemy[i].bounds.Overlaps(player.bounds))
					{
						if(player.canBeHit)
						{
							AppMain.audioManager.SetSFX(2);
							player.health = player.health - enemy[i].damage;
							player.canBeHit = false;
							multiplier = 1;
						}
					}
				}
			}
			
			for(int i = 0; i < 9; i++)
			{
				player.player.GetContentWorldBounds (ref player.bounds);
				platforms[i].sprite.GetContentWorldBounds (ref platforms[i].bounds);
				
				if(player.yVelocity < 0)
				{
					if(player.bounds.Overlaps(platforms[i].bounds))
					{
						if(player.playerPos.Y > (platforms[i].position.Y + (platforms[i].platformHeight / 2)))
						{
							player.playerPos.Y = (platforms[i].position.Y + platforms[i].platformHeight);
							player.player.Position = player.playerPos;
							player.onGround = true;
						}
					}
				}
				
				if(player.yVelocity == 0)
				{
					if(!player.bounds.Overlaps(platforms[i].bounds) && player.playerPos.Y != 0.0f)
					{
						player.onGround = false;
					}
				}
			}
			if (collectibleActive)
			{
				collectible.sprite.GetContentWorldBounds (ref collectible.bounds);
				player.player.GetContentWorldBounds (ref player.bounds);
				if(player.yVelocity < 0 && player.bounds.Overlaps(collectible.bounds))
				{
					int collectibleType = collectible.getType();
					collectible.delete(gameScene);
					collectible = null;
					collectibleActive = false;
					accumulatedDeltaTime = 0.0f;
					switch (collectibleType)
					{
    					case 0:
							player.health += 2;
							if (player.health > 10)
							{
								player.health = 10;	
							}
							healthLabel.Text = "Health: " + player.health;
        				break;
    					case 1:
							player.ammo += 10;
							if (player.ammo > 100)
							{
								player.ammo = 100;	
							}
							ammoLabel.Text = "Ammo: " + player.ammo;
        				break;
						case 2:
	        				multiplier++;
							multiplierLabel.Text = "Multiplier: x" + multiplier;
        				break;
						case 3:
							if (specMoveProg < 8)
							{
		        				specMoveProg++;
							}
							switch (specMoveProg)
							{
    						case 1:
								rainbowLabel.Text = "R";
        					break;
    						case 2:
								rainbowLabel.Text = "RA";
       						break;
							case 3:
								rainbowLabel.Text = "RAI";
        					break;
							case 4:
								rainbowLabel.Text = "RAIN";
        					break;
							case 5:
								rainbowLabel.Text = "RAINB";
        					break;
							case 6:
								rainbowLabel.Text = "RAINBO";
        					break;
 							default:
								rainbowLabel.Text = "RAINBOW";
        					break;
							}
						break;
						default:
												
						break;
					}
				}
			}
		}
		
		public static void LoadLevel()
		{	
			if (!gameStart)
			{
				//Load level manager
				levelManager = new LevelManager();
			
				//Load audio manager
				audioManager = new AudioManager();
				
				//Create the background.
				background = new Background(gameScene);
			
				//uiSceneManager = new UISceneManager();
			}
			else
			{				
				//Hardcoded platform locations
				platforms = new Platform[9];
				platforms[0] = new Platform(gameScene, new Vector2(0, 136));
				platforms[1] = new Platform(gameScene, new Vector2(0, 272));
				platforms[2] = new Platform(gameScene, new Vector2(0, 408));
				platforms[3] = new Platform(gameScene, new Vector2(380, 200));
				platforms[4] = new Platform(gameScene, new Vector2(380, 340));
				platforms[5] = new Platform(gameScene, new Vector2(380, 60));
				platforms[6] = new Platform(gameScene, new Vector2(760, 136));
				platforms[7] = new Platform(gameScene, new Vector2(760, 272));
				platforms[8] = new Platform(gameScene, new Vector2(760, 408));
				
				//Create the player
				player = new Player(gameScene, new Vector2(0,0));
				
				//Create an enemy
									
				//Value for progress through collecting letters for special move
				specMoveProg = 0;	
				
				healthLabel.Text = "Health: " + player.health;
				scoreLabel.Text = "" + score;
				ammoLabel.Text = "Ammo: " + player.ammo;
				multiplierLabel.Text = "Mutiplier: x" + multiplier;
				rainbowLabel.Text = "";
				
				for(int i = 0; i< 10; i++)
				{ 
					//so this thing counts to 300 ms then spawns an enemy, then repeats
					while(enemyCoolTime < 50)
					{
						currentTime = (float)timer.Milliseconds();
						elapsedTime = currentTime - previousTime;
						previousTime = currentTime;
						enemyCoolTime+= elapsedTime;
					}
					if (enemyCoolTime >= 50)
					{	//when the timer reaches 300ms, it creates a new enemy and sets it to alive, then loads it.  I changed that stuff for respawning.
						enemyCoolTime = 0.0f;
						enemy[i] = new Enemy(gameScene);
						enemy[i].isAlive = true;
						enemy[i].Load (gameScene);
					}	
				}
			}
		}	
	}
}