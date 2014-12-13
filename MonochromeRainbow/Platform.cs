using System;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;


namespace MonochromeRainbow
{
	public class Platform
	{
		private TextureInfo	textureInfo;
		
		public SpriteUV	sprite;
		public Bounds2	bounds;
		public Vector2	position;
		public float	platformHeight;
		public float	platformWidth;
		
		public Platform (Scene scene, Vector2 pos)
		{
			position = new Vector2();
			position = pos;
			sprite	= new SpriteUV();
			
			textureInfo	= new TextureInfo("/Application/textures/Platform.png");
			
			sprite			= new SpriteUV(textureInfo);
			sprite.Quad.S	= textureInfo.TextureSizef;
			sprite.Position = pos;
			
			platformHeight	= sprite.Quad.S.Y;
			platformWidth	= sprite.Quad.S.X;
			
			scene.AddChild(sprite);
		}
	}
}

