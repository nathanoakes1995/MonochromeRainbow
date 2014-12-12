using System;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;


namespace FlappyBird
{
	public class Enemy
	{
		private 	SpriteUV 	sprite;
		private	 	TextureInfo	textureInfo;
		private		Vector2 	position;
		private 	Vector2[] 	spawnPositions;
		public Enemy (Scene scene)
		{
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
			spawnPositions[8] = new Vector2(20,138);
			spawnPositions[0] = new Vector2(20,272);
			spawnPositions[1] = new Vector2(20,408);
			spawnPositions[2] = new Vector2(400,200);
			spawnPositions[3] = new Vector2(400,340);
			spawnPositions[4] = new Vector2(400,60);
			spawnPositions[5] = new Vector2(780, 136);
			spawnPositions[6] = new Vector2(780, 272);
			spawnPositions[7] = new Vector2(780, 408);
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
			
		}
		
		public void Update()
		{
			
		}
		public void RunAI(Vector2 playerLocation)
		{
			if (position.X < playerLocation.X)
			{
				position.X -= 0.1f;	
			}
			if (position.X > playerLocation.X)
			{
				position.X += 0.1f;	
			}
		}
	
	}
}

