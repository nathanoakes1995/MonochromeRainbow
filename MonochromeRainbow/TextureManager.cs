using System;
using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;


namespace MonochromeRainbow
{
	public class TextureManager
	{
		public SpriteUV sprite;
		public TextureInfo textureInfo;
		public Vector2 textureSize;
		public Scene scene1;
		public Vector2 position;
		
		public TextureManager (string path, Scene scene)
		{
			textureInfo = new TextureInfo(path);
			
			sprite = new SpriteUV();
			sprite = new SpriteUV(textureInfo);
			sprite.Quad.S = textureInfo.TextureSizef;
			sprite.Position = position;
			scene.AddChild(sprite);
		}
		
		
		public void Animate()
		{
			
		}
	}
}

