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
		public Bounds2 bounds;
		public Enemy (Scene scene, Vector2 pos)
		{
			
			sprite	= new SpriteUV();
			bounds = new Bounds2();
			
			textureInfo	= new TextureInfo("/Application/textures/GenericTexture.png");
			
			sprite			= new SpriteUV(textureInfo);
			sprite.Quad.S	= textureInfo.TextureSizef;
			sprite.Position = pos;
			
			scene.AddChild(sprite);
			
			//Update();
		}
		
		
		public void Update()
		{
			
		}
		
		public void Draw()
		{
			
		}
	}
}

