using System;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;


namespace FlappyBird
{
	public class Enemy
	{
		public Vector2 position;
		public TextureManager textureManager;
		
		public Enemy (Scene scene)
		{
			Initialise (scene);	
		}
		public void Initialise(Scene pointerScene)
		{
			position = new Vector2(100.0f,100.0f);
			textureManager = new TextureManager("/Application/textures/GenericTexture.png", pointerScene);
			
			
		}
		
		public void Update()
		{
			
		}
		
		public void Draw()
		{
			
		}
	}
}

