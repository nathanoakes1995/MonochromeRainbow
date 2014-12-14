using System;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;


namespace MonochromeRainbow
	
{
	public class Enemy
	{
		private	TextureInfo	textureInfo;
		public bool				isAlive = false;
		public float			yVelocity;
		public TextureInfo[]	textures;
		public bool 			onGround;
		public int 				type;
		public int 				behavior;
		public int 				health;
		public int 				damage;
		public Bounds2			bounds;
		public Vector2			position;
		public Vector2[]		spawnPositions;
		public SpriteUV			sprite;
		public bool				mayJumpAgain;
	
		public Enemy (Scene scene)
		{
		}
		
		public void Load(Scene scene)
		{
			textures = new TextureInfo[1];
			//the reason this isn't in the constructor is because the enemies need to respawn.
			DecideType ();
			
			spawnPositions = new Vector2[9];
			SetSpawnLocations();
			sprite	= new SpriteUV();
			
			SetEnemyArray();
			
			textureInfo = new TextureInfo();
			textureInfo = textures[0];
			sprite			= new SpriteUV(textureInfo);
			sprite.Quad.S	= textureInfo.TextureSizef;
			bounds = new Bounds2();
			DecideSpawnLocation ();
			yVelocity = 5.0f;
			onGround = false;
			scene.AddChild(sprite);
		}
		
		public void SetEnemyArray()
		{
			textures = new TextureInfo[3];
			textures[0]		= new TextureInfo("/Application/textures/enemy/flyingEnemy.png");
			textures[1]		= new TextureInfo("/Application/textures/enemy/regularEnemy.png");
			textures[2]		= new TextureInfo("/Application/textures/enemy/heavyEnemy.png");	
		}
		
		public void DecideType()
		{
		
			//Decide random type
			Random rnd = new Random();
			
			//Flying Enemy
			if(randomNumber() <= 50)
			{
				behavior = 1;
				health = 5;
				damage = 1;
				
				textureInfo = textures[0];
			}
			
			//Normal enemy
			if(50 < randomNumber() && randomNumber() <= 85)
			{
				behavior = 0;
				health = 3;
				damage = 1;	
				
				textureInfo = textures[1];
			}
			
			//Tanky Enemy
			if(85 < randomNumber())
			{
				behavior = 2;
				health = 7;
				damage = 3;
				
				textureInfo = textures[2];
			}	
		}
		
		public int randomNumber()
		{
			var randGen = new Random(Guid.NewGuid().GetHashCode());
			int randInt = randGen.Next (100);
			
			return randInt;
		}
		
		public void SetSpawnLocations()
		{
			//Create array of potential spawn positions (set to the platform XY positions.
			//Added 20 to each one because of Y0 being at the bottom.
			spawnPositions[8] = new Vector2(0,158);
			spawnPositions[0] = new Vector2(0,292);
			spawnPositions[1] = new Vector2(0,428);
			spawnPositions[2] = new Vector2(380,220);
			spawnPositions[3] = new Vector2(380,360);
			spawnPositions[4] = new Vector2(380,80);
			spawnPositions[5] = new Vector2(760, 156);
			spawnPositions[6] = new Vector2(760, 292);
			spawnPositions[7] = new Vector2(760, 428);
		}
		
		public void DecideSpawnLocation()
		{
			if(type == 1)
			{
				Random rnd = new Random();
				int num = rnd.Next(0,961);
				position = new Vector2(num, 500);
			}
			else
			{
				//Create random number
				Vector2 randPos = new Vector2();
				Random rnd = new Random();
				int num = rnd.Next (0,9);
				//choose an item in spawnPositions based on the random number
				randPos = spawnPositions[num];
				//set the position to that item in the array
				sprite.Position = new Vector2();
				sprite.Position = randPos;
				position = randPos;
				num = rnd.Next (0,9);
			}
		}
		
		public void Update()
		{
			sprite.Position = position;
		}
		
		public void RunAI(Vector2 playerLocation)
		{
		
			if(type == 0)
				RunAIType1 (playerLocation);
			else if(type == 1)
				RunAIType2 (playerLocation);
			else if(type==2)
				RunAIType3 (playerLocation);
		}
		
		public void RunAIType1(Vector2 playerLocation)
		{
			//normalAI
			
			if (onGround)
			{
				yVelocity = 0;
				
				if (mayJumpAgain)
				{
                	if(playerLocation.Y > position.Y)
					{
						yVelocity = 11.0f;
						mayJumpAgain = false;
					}
				}
        		else if (onGround)
				{
					mayJumpAgain = true;
        		}
			}
			
			//moves towards the player
			if (position.X < playerLocation.X)
			{
				position.X += 0.9f;	
			}
			if (position.X > playerLocation.X)
			{
				position.X -= 0.9f;	
			}
						
			//Check if enemy is off the ground.
			if (!onGround)
			{
        		//Enemy loses vertical speed tue to gravity.
				yVelocity -= 0.5f;
			}
			
			//Enemy shouldn't fall too fast. [Terminal Velocity]
			if (yVelocity < -5.0f)
			{
        		yVelocity = -5.0f;
			}
			
			//Check if enemy is on the ground.
            if (yVelocity != 0.0f)
			{
				onGround = false;
    		}
			
			//checks if enemy has hit the ground.
			if (position.Y < 0.0f)
			{
				position.Y = 0.0f;
				onGround = true;
			}
			
			position.Y += yVelocity;
		}
		
		public void RunAIType2(Vector2 playerLocation)
		{
			//flying AI
		
			//moves towards the player on the X axis
			if (position.X < playerLocation.X)
			{
				position.X += 0.7f;	
				sprite.Position = position;
			}
			if (position.X > playerLocation.X)
			{
				position.X -= 0.7f;	
				sprite.Position = position;
			}
			if (position.Y < playerLocation.Y)
			{
				position.Y += 0.7f;	
				sprite.Position = position;
			}
			if (position.Y > playerLocation.Y)
			{
				position.Y -= 0.7f;	
				sprite.Position = position;
			}
		}
		
		public void RunAIType3(Vector2 playerLocation)
		{
			//normalAI
			
			if (onGround)
			{
				yVelocity = 0;
			}
			
			//moves towards the player
			if (position.X < playerLocation.X)
			{
				position.X += 0.9f;	
			}
			if (position.X > playerLocation.X)
			{
				position.X -= 0.9f;	
			}
						
			//Check if enemy is off the ground.
			if (!onGround)
			{
        		//Enemy loses vertical speed tue to gravity.
				yVelocity -= 0.5f;
			}
			
			//Enemy shouldn't fall too fast. [Terminal Velocity]
			if (yVelocity < -5.0f)
			{
        		yVelocity = -5.0f;
			}
			
			//Check if enemy is on the ground.
            if (yVelocity != 0.0f)
			{
				onGround = false;
    		}
			
			//checks if enemy has hit the ground.
			if (position.Y < 0.0f)
			{
				position.Y = 0.0f;
				onGround = true;
			}
			
			position.Y += yVelocity;
		}
	}
}

