using System;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;


namespace FlappyBird
{
	public class Enemy
	{
		private	SpriteUV	sprite;
		private	TextureInfo	textureInfo;
		
		public float 		yVelocity;
		public bool 		onGround;
		public Bounds2		bounds;
		public Vector2		position;
		public Vector2[]	spawnPositions;
		
		public Enemy (Scene scene)
		{
			yVelocity = 5.0f;
			onGround = false;
			spawnPositions = new Vector2[9];
			SetSpawnLocations();
			sprite	= new SpriteUV();
			textureInfo	= new TextureInfo("/Application/textures/GenericTexture.png");
			sprite			= new SpriteUV(textureInfo);
			sprite.Quad.S	= textureInfo.TextureSizef;
			DecideSpawnLocation ();
			
			scene.AddChild(sprite);
			
			
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
			
			
		}
		
		public void Update()
		{
			//bit of simple gravity so that the enemies aren't anchored to the platforms
			
			//if enemy is on ground, velocity = 0
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
			
			//moves the enemy down if not on the ground
			if(onGround == false)
			{
				position.Y -= yVelocity;	
			}
			
			//update position every frame
			sprite.Position = position;
		}
		public void RunAI(Vector2 playerLocation)
		{
			
			//simple AI for now that just follows the player around the X axis
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
	
	}
}

