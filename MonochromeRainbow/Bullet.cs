using System;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;


namespace MonochromeRainbow
{
	public class Bullet
	{
		private 	SpriteUV 	sprite;
		private	 	TextureInfo	textureInfo;
		
		public Bullet (Scene scene, Vector2 position, int direction)
		{
			
			sprite	= new SpriteUV();
			
			textureInfo	= new TextureInfo("/Application/textures/bullet.png");
			
			sprite			= new SpriteUV(textureInfo);
			sprite.Quad.S	= textureInfo.TextureSizef;
			sprite.Position = position;
			
			scene.AddChild(sprite);
		}
				
		public void Update()
		{
			
		}
		
		public void Draw()
		{
			
		}
	}
}


