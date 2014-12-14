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
		private static Sce.PlayStation.HighLevel.GameEngine2D.Scene 	gameScene;
		private static Sce.PlayStation.HighLevel.UI.Scene 				uiScene;
		private static Sce.PlayStation.HighLevel.UI.Label				scoreLabel;
		private static Sce.PlayStation.HighLevel.UI.Label				healthLabel;
		private static Sce.PlayStation.HighLevel.UI.Label				ammoLabel;
		private static Sce.PlayStation.HighLevel.UI.Label				multiplierLabel;
		private static Sce.PlayStation.HighLevel.UI.Label				rainbowLabel;
		
		public static GamePadData	gamePadData;
		public static Timer enemyTimer = new Timer();
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
<<<<<<< HEAD
		
		public static Screen		screen;
=======
		public static bool 	enemyCanBeSpawned;
		//public static Menu 			menu;
>>>>>>> origin/master
		public static Background	background;
		private MainMenu	mainMenu;
		public static AudioManager	audioManager;
		public static LevelManager	levelManager;
		public static Collectibles	collectible;
		public static Platform[]	platforms;
		public static Timer			timer;
		
		public static Player		player;
		public static Enemy[]		enemy;
		public static Bullet		bullet;
			
		public static void Main (string[] args)
		{					
			timer = new Timer();
			previousTime = (float)timer.Milliseconds();
			
			Initialize();
			
			//Game loop
			bool quitGame = false;
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
			level = 5;
			multiplier = 1;
			
			LoadLevel(level);		
			
			AppMain.audioManager.SetBGM(level);
			AppMain.audioManager.PlayBGM();
			
			//Run the scene.
			Director.Instance.RunWithScene(gameScene, true);
		}
		
		public static void Update()
		{
			currentTime = (float)timer.Milliseconds();
			elapsedTime = currentTime - previousTime;
			previousTime = currentTime;
			
			accumulatedDeltaTime += elapsedTime;
			
			//Get gamepad input.
			gamePadData = GamePad.GetData(0);
			if(level == 5)
			{
			
				//Collectible update
				if (collectibleActive)
				{
					collectible.Update();
				}
				
				score += 1 * multiplier;
				scoreLabel.Text = "" + score;
				
				if (!collectibleActive)
				{
					if (accumulatedDeltaTime >= 2000)
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
				player.Update(levelManager.level, gameScene);
				int health = player.health;
				
				//Background update
				background.Update(gameScene, health, levelManager.level);
				
				//Update EnemyAI
				for(int i = 0; i< 20; i++)
				{//checks to see if enemy is alive
					if(enemy[i].isAlive)
					{	//runs AI for living enemy
						enemy[i].RunAI (player.playerPos);
						enemy[i].Update ();
					}
					
					else
					{	//respawns a dead one
						SpawnEnemy (i);
					}
				}
				
				level = levelManager.level;
				healthLabel.Text = "Health: " + player.health;
				CheckCollision();
			}
		}
		
		public static void SpawnEnemy(int whichEnemy)
		{		
			//for spawning a new enemy if one is dead.
			enemy[whichEnemy].isAlive = true;
			enemy[whichEnemy].Load (gameScene);
			
						
			
		}
		
		public static void CheckLevel()
		{
		}
		
		public static void CheckCollision()
		{
			for(int i = 0; i < 20; i++)
			{
				if(enemy[i].isAlive)
				{
					enemy[i].sprite.GetContentWorldBounds(ref enemy[i].bounds);	
					for(int k = 0; k< 9; k++)
					{
						platforms[k].sprite.GetContentWorldBounds (ref platforms[k].bounds);	
						if(enemy[i].bounds.Overlaps(platforms[k].bounds))
						{
							enemy[i].position.Y = (platforms[k].position.Y + 20);
							enemy[i].sprite.Position= enemy[i].position;
						}
					}
					player.player.GetContentWorldBounds (ref player.bounds);
					if(enemy[i].bounds.Overlaps (player.bounds))
					{
						if(player.canBeHit)
						{
							player.health = player.health - enemy[i].damage;
							player.canBeHit = false;
						}
					}
				}
			}
			
			for(int i = 0; i < 9; i++)
			{
				platforms[i].sprite.GetContentWorldBounds (ref platforms[i].bounds);
				player.player.GetContentWorldBounds (ref player.bounds);
				if(player.yVelocity < 0)
				{
					if((player.playerPos.X + player.player.Quad.S.X) > (platforms[i].position.X + 20.0f) && player.playerPos.X < (platforms[i].position.X + platforms[i].platformWidth - 18.0f))
					{
						if(player.bounds.Overlaps(platforms[i].bounds))
						{
							if(player.playerPos.Y > (platforms[i].position.Y + (platforms[i].platformHeight / 2)))
							{
								player.playerPos.Y = (platforms[i].position.Y + platforms[i].platformHeight) - 4.0f;
								player.player.Position = player.playerPos;
								player.onGround = true;
							}
						}
					}
				}
				if(player.yVelocity == 0)
				{
					if(!player.bounds.Overlaps(platforms[i].bounds) && player.playerPos.Y != -5.0f)
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
		
		public static void LoadLevel(int level)
		{	
			//Load level manager
			levelManager = new LevelManager();
			
			//Create up audio
			audioManager = new AudioManager();
			
			screen = new Screen(gameScene, level);
			
			if(level == 5)
			{
				//Create the background.
				background = new Background(gameScene);
				
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
				
				
				//Create a bullet
				bullet = new Bullet(gameScene, new Vector2(300,300), 1);
				
									
				//Value for progress through collecting letters for special move
				specMoveProg = 0;	
				
				healthLabel.Text = "Health: " + player.health;
				scoreLabel.Text = "" + score;
				ammoLabel.Text = "Ammo: " + player.ammo;
				multiplierLabel.Text = "Mutiplier: x" + multiplier;
				rainbowLabel.Text = "";
				
				for(int i = 0; i< 20; i++)
				{ //so this thing counts to 300 ms then spawns an enemy, then repeats
					while(enemyCoolTime < 300)
					{
						currentTime = (float)timer.Milliseconds();
						elapsedTime = currentTime - previousTime;
						previousTime = currentTime;
						enemyCoolTime+= elapsedTime;
					}
					if (enemyCoolTime >= 300)
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