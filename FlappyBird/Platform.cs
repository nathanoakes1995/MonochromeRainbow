using System;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;


namespace FlappyBird
{
	public class Platform
	{
		private 	SpriteUV 	sprite;
		private	 	TextureInfo	textureInfo;
		public Bounds2 bounds;
		public Platform (Scene scene, Vector2 pos)
		{
			sprite	= new SpriteUV();
			
			textureInfo	= new TextureInfo("/Application/textures/Platform.png");
			bounds = new Bounds2();
			Rectangle rect;
			
			
			sprite			= new SpriteUV(textureInfo);
			sprite.Quad.S	= textureInfo.TextureSizef;
			sprite.Position = pos;
			
			scene.AddChild(sprite);
		}
	}
}

