using System;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace MonochromeRainbow
{
	public class Button
	{
		public TextureInfo texture;
		public SpriteUV sprite;
		public Bounds2 bounds;
		
		public Button (Scene scene, Vector2 position)
		{
			bounds = new Bounds2();
			texture = new TextureInfo(path);
			sprite = new SpriteUV(texture);
			sprite.Quad.S = texture.TextureSizef;
			sprite.Position = position;
			scene.AddChild (sprite);
		}
	}
}

