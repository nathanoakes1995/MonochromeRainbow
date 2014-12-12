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
		
		public Enemy (Scene scene, Vector2 pos)
		{
			
			sprite	= new SpriteUV();
			
			textureInfo	= new TextureInfo("/Application/textures/GenericTexture.png");
			
			sprite			= new SpriteUV(textureInfo);
			sprite.Quad.S	= textureInfo.TextureSizef;
			sprite.Position = pos;
			
			scene.AddChild(sprite);
			
			
		}
		
		
		public void Update()
		{
			
		}
	}
}

