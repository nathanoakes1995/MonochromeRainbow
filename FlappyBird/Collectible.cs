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
		public int spawnPos;
		public bool movingUp;
		
		
		public Collectibles (Scene scene, int specMoveProg)
		{
			movingUp = true;
			position = decideSpawnPos();
			extraHeight = 0.0f;
			startHeight = position.Y;
			type = decideCollectible();
			if (type == 0)
			{
				textureInfo = new TextureInfo("/Application/textures/Health.png");
			}
			else if (type == 1)
			{
				textureInfo = new TextureInfo("/Application/textures/Ammo.png");
			}
			
			else if (type == 2)
			{
				textureInfo = new TextureInfo("/Application/textures/Multiplier.png");
			}
			else
			{
				switch (specMoveProg)
				{
    			case 0:
					textureInfo = new TextureInfo("/Application/textures/1-R.png");
        		break;
    			case 1:
					textureInfo = new TextureInfo("/Application/textures/2-A.png");
       			break;
				case 2:
					textureInfo = new TextureInfo("/Application/textures/3-I.png");
        		break;
				case 3:
					textureInfo = new TextureInfo("/Application/textures/4-N.png");
        		break;
				case 4:
					textureInfo = new TextureInfo("/Application/textures/5-B.png");
        		break;
				case 5:
					textureInfo = new TextureInfo("/Application/textures/6-O.png");
        		break;
 				default:
					textureInfo = new TextureInfo("/Application/textures/7-W.png");
        		break;
				}
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
			if (movingUp)
			{
				extraHeight += 0.1f;
				if (position.Y >= startHeight + 10)
				{
				movingUp = false;	
				}
			}
			else
			{
				extraHeight -= 0.1f;
				if (position.Y <= startHeight)
				{
				movingUp = true;	
				}
			}
			position.Y = (startHeight + extraHeight);
			sprite.Position = position;
			
			
		}
		
		public void Draw() 
		{
			
		}
		
		public Vector2 decideSpawnPos()
		{
			var randGen = new Random(Guid.NewGuid().GetHashCode());
			int randInt = randGen.Next (4);
			
			if (randInt == 0)
			{
				Vector2 posVec = new Vector2(110.0f,180.0f);
				return posVec;
			}
			else if (randInt == 1)
			{
				Vector2 posVec = new Vector2(850.0f,180.0f);
				return posVec;
			}
			else if (randInt == 2)
			{
				Vector2 posVec = new Vector2(110.0f,450.0f);
				return posVec;
			}
			else
			{
				Vector2 posVec = new Vector2(850.0f,450.0f);
				return posVec;
			}
						
		}
		
		
		public int decideCollectible()
		{
			//int playerHealth = 10;
			//int playerAmmo = 100;	
			//bool multiplierActive = false;
			//int numberSinceLetter = 5;
			var randGen = new Random(Guid.NewGuid().GetHashCode());
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

