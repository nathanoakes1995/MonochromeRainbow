using System;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Audio;

namespace MonochromeRainbow
{
	public class AudioManager
	{
		private BgmPlayer	BGMPlayer;
  		private Bgm[]		BGM;
		
		public bool	BGMPlaying;
		
		public AudioManager ()
		{
			SetBGMArray();
			
			BGMPlayer = BGM[0].CreatePlayer();
		}
		
		public void SetBGMArray()
		{
			BGM = new Bgm[7];
			BGM[0]	= new Bgm("/Application/sounds/bgm/Pamgaea.mp3");	
			BGM[1]	= new Bgm("/Application/sounds/bgm/Mining by Moonlight.mp3");
			BGM[2]	= new Bgm("/Application/sounds/bgm/Local Forecast - Elevator.mp3");
			BGM[3]	= new Bgm("/Application/sounds/bgm/Son Of A Rocket.mp3");		
			BGM[4]	= new Bgm("/Application/sounds/bgm/Rollin at 5.mp3");	
			BGM[5]	= new Bgm("/Application/sounds/bgm/Rollin at 5 - electronic.mp3");	
			BGM[6]	= new Bgm("/Application/sounds/bgm/One Sly Move.mp3");		
		}
		
		public void SetSFXArray()
		{
		}
		
		public void SetBGM(int level)
		{
			BGMPlayer.Dispose();
			
			BGMPlayer = BGM[level].CreatePlayer();
		}
		
		public void PlayBGM()
		{
			BGMPlayer.Loop = true;
			BGMPlayer.Play();
			
			BGMPlaying = true;
		}
		
		public void StopBGM()
		{
			BGMPlayer.Stop();
			
			BGMPlaying = false;
		}
		 
		public void Dispose()
		{
			BGMPlayer.Dispose();
		}
	}
}
