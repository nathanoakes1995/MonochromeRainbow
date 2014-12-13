using System;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace MonochromeRainbow
{
	public class Collectibles
	{
		private TextureInfo	textureInfo;
		
		public int		type;
		public int		spawnPos;
		public float	extraHeight;
		public float	startHeight;
		public bool		movingUp;
		public Bounds2	bounds;
		public Vector2	position;
		public SpriteUV sprite;
		
		public Collectibles (Scene scene, int specMoveProg)
		{
			movingUp = true;
			position = decideSpawnPos();
			extraHeight = 0.0f;
			startHeight = position.Y;
			type = decideCollectible();
			//Health Collectible Texture
			if (type == 0)
			{
				textureInfo = new TextureInfo("/Application/textures/Health.png");
			}
			//Ammo Collectible Texture
			else if (type == 1)
			{
				textureInfo = new TextureInfo("/Application/textures/Ammo.png");
			}
			//Mutiplier Collectible Texture
			else if (type == 2)
			{
				textureInfo = new TextureInfo("/Application/textures/Multiplier.png");
			}
			//Finisher Move Collectible Textures
			else
			{
				//Different texture depending on which letter was collected last
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
			sprite 			= new SpriteUV(textureInfo);
			sprite.Quad.S 	= textureInfo.TextureSizef;
			sprite.Position = position;
			//Get sprite bounds.
			Bounds2 b = sprite.Quad.Bounds2();
						
			//Add to the current scene.
			scene.AddChild(sprite);
		}
				
		public void Update()
		{
			//Float up
			if (movingUp)
			{
				extraHeight += 0.1f;
				if (position.Y >= startHeight + 10)
				{
				movingUp = false;	
				}
			}
			//Float down
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
			//Randomly decide on of 4 spawn positions
			var randGen = new Random(Guid.NewGuid().GetHashCode());
			int randInt = randGen.Next (4);
			
			if (randInt == 2)
			{
				Vector2 posVec = new Vector2(110.0f,180.0f);
				return posVec;
				//Bottom Left
			}
			else if (randInt == 1)
			{
				Vector2 posVec = new Vector2(850.0f,180.0f);
				return posVec;
				//Bottom Right
			}
			else if (randInt == 2)
			{
				Vector2 posVec = new Vector2(110.0f,450.0f);
				return posVec;
				//Top Right
			}
			else
			{
				Vector2 posVec = new Vector2(850.0f,450.0f);
				return posVec;
				//Top Left
			}
						
		}
		
		public int decideCollectible()
		{
			//Randomly decide which collectible to spawn
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
		
		public void delete(Scene scene)
		{
			scene.RemoveChild(sprite, true);
		}
		public int getType()
		{
			return type;	
		}
	}
}

