using System;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;


namespace FlappyBird
{
	public class Platform
	{
		private 	SpriteUV 	sprite;
		private	 	TextureInfo	textureInfo;
		public Bounds2 b;
		public Platform (Scene scene, Vector2 pos)
		{
			sprite	= new SpriteUV();
			b = new Bounds2();
			textureInfo	= new TextureInfo("/Application/textures/Platform.png");
			
			sprite			= new SpriteUV(textureInfo);
			sprite.Quad.S	= textureInfo.TextureSizef;
			sprite.Position = pos;
			
			scene.AddChild(sprite);
		}
		
	}
}

