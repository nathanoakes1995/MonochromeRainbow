using System;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace FlappyBird
{
	public class Player
	{
		private	static SpriteUV		player;
		private	static TextureInfo	textureInfo;
		
		public static int Health;
		public static int Ammo;
		
		public Player (Scene scene)
		{
			textureInfo	= new TextureInfo("/Application/textures/Player.png");
			
			Health = 10;
			Ammo = 100;
			
			player			= new SpriteUV(textureInfo);	
			player.Quad.S 	= textureInfo.TextureSizef;
			player.Position = new Vector2(50.0f,Director.Instance.GL.Context.GetViewport().Height*0.5f);
			
			scene.AddChild(player);
		}
	}
}

