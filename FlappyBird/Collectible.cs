using System;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace FlappyBird
{
	public class Collectibles
	{
		
		public Vector2 position;
		
		private SpriteUV 	sprite;
		private TextureInfo	textureInfo;
		public int type;
		public float extraHeight;
		public float startHeight;
		
		
		public Collectibles (Scene scene)
		{
			//sprites	= new SpriteUV[];
			startHeight = 200.0f;
			extraHeight = 0.0f;
			position = new Vector2(200.0f,startHeight + extraHeight);
			type = decideCollectible();
			if (type == 0)
			{
				textureInfo = new TextureInfo("/Application/textures/bird.png");
			}
			else if (type == 1)
			{
				textureInfo = new TextureInfo("/Application/textures/bird1.png");
			}
			
			else if (type == 2)
			{
				textureInfo = new TextureInfo("/Application/textures/bird2.png");
			}
			else
			{
				textureInfo = new TextureInfo("/Application/textures/bird3.png");
			}
			//Left
			sprite 			= new SpriteUV(textureInfo);
			sprite.Quad.S 	= textureInfo.TextureSizef;
			sprite.Position = position;
			//Get sprite bounds.
			Bounds2 b = sprite.Quad.Bounds2();
			
			
			//Add to the current scene.
			//foreach(SpriteUV sprite in sprites)
				scene.AddChild(sprite);

		}
		
		
		
		public void Update()
		{
			extraHeight += 0.1f;
			position = new Vector2(200.0f,startHeight + extraHeight);
			sprite.Position = position;
		}
		
		public void Draw() 
		{
			
		}
		
		public int decideCollectible()
		{
			//int playerHealth = 10;
			//int playerAmmo = 100;	
			//bool multiplierActive = false;
			//int numberSinceLetter = 5;
			var randGen = new Random(Guid.NewGuid().GetHashCode());;
			int randInt = randGen.Next (100);
						

				if (randInt <= 39)
				{
					return 0;
					//Health	
				}
				else if (randInt <= 79)
				{
					return 1;
					//Ammo	
				}
				else if (randInt <= 94)
				{
					return 2;
					//Multiplier	
				}
				else
				{
					return 3;
					//Letters	
				}
			
				
		}
	}
}

