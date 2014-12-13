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
		
		public float 		yVelocity;
		public bool 		onGround;
		public int 			type;
		public int 			behavior;
		public int 			health;
		public int 			damage;
		public Bounds2		bounds;
		public Vector2		position;
		public Vector2[]	spawnPositions;
		public SpriteUV		sprite;
		
		public Enemy (Scene scene)
		{
			DecideType ();
			yVelocity = 5.0f;
			onGround = false;
			spawnPositions = new Vector2[9];
			SetSpawnLocations();
			sprite	= new SpriteUV();
			
			sprite			= new SpriteUV(textureInfo);
			sprite.Quad.S	= textureInfo.TextureSizef;
			DecideSpawnLocation ();
			
			scene.AddChild(sprite);
			
			
		}
		public void DecideType()
		{
			//Decide random type
			Random rnd = new Random();
			type = rnd.Next (0,3);
			//Normal enemy
			if(type == 0)
			{
				textureInfo	= new TextureInfo("/Application/textures/Enemytex.png");
				behavior = 0;
				health = 3;
				damage = 1;
				
			}
			//Flying Enemy
			else if (type == 1)
			{
				textureInfo = new TextureInfo("/Application/textures/Flyer.png");
				behavior = 1;
				health = 5;
				damage = 2;
				
			}
			//Tanky Enemy
			else if (type ==2)
			{
				textureInfo = new TextureInfo("/Application/textures/tank.png");
				behavior = 2;
				health = 7;
				damage = 3;
				
			}
			
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
			//bit of simple gravity so that the enemies aren't anchored to the platforms
			
			//if enemy is on ground, velocity = 0
			
			
			//moves the enemy down if not on the ground
			
			//update position every frame
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
			if (position.X < playerLocation.X)
			{
				position.X += 0.5f;	
				sprite.Position = position;
			}
			if (position.X > playerLocation.X)
			{
				position.X -= 0.5f;	
				sprite.Position = position;
			}
			if(onGround == false)
			{
				yVelocity = 5.0f;
			}
			else if (onGround == true)
			{
				yVelocity = 0.0f;
			}	
			
			//checks if enemy is on the ground
			if (position.Y < 0.0f)
			{
				position.Y = 0.0f;
				onGround = true;
			}
			if(onGround == false)
			{
				position.Y -= yVelocity;	
			}
			
		}
		
		public void RunAIType2(Vector2 playerLocation)
		{
			//flying AI
			if (position.X < playerLocation.X)
			{
				position.X += 0.5f;	
				sprite.Position = position;
			}
			if (position.X > playerLocation.X)
			{
				position.X -= 0.5f;	
				sprite.Position = position;
			}
		}
		
		public void RunAIType3(Vector2 playerLocation)
		{
			
		}
	
	}
}

