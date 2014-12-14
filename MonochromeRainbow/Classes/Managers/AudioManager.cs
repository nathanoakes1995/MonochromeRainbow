using System;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Audio;

namespace MonochromeRainbow
{
	public class AudioManager
	{
		private BgmPlayer	BGMPlayer;
  		private Bgm[]		BGM;
		
		private SoundPlayer	SFXPlayer;
  		private Sound[]		SFX;
		
		public int	gameSong;
		public int	pauseSong;
		public bool	BGMPlaying;
		public bool	SFXPlaying;
		public double gameTime;
		public double pauseTime;
		public bool inGame;
		public bool hasPaused;
		public bool wasGame;
		public bool wasPaused;
		
		public AudioManager()
		{
			SetBGMArray();
			SetSFXArray();
			
			BGMPlayer =	BGM[0].CreatePlayer();
			SFXPlayer = SFX[0].CreatePlayer();
			
			BGMPlayer.Loop = true;
			SFXPlayer.Loop = false;
		}
		
		public void SetBGMArray()
		{
			BGM = new Bgm[8];
			BGM[0]	= new Bgm("/Application/sounds/bgm/Pamgaea.mp3");	
			BGM[1]	= new Bgm("/Application/sounds/bgm/Local Forecast - Elevator.mp3");
			BGM[2]	= new Bgm("/Application/sounds/bgm/Son Of A Rocket.mp3");
			BGM[3]	= new Bgm("/Application/sounds/bgm/Rollin at 5.mp3");	
			BGM[4]	= new Bgm("/Application/sounds/bgm/Rollin at 5 - electronic.mp3");	
			BGM[5]	= new Bgm("/Application/sounds/bgm/Doh De Oh.mp3");
			BGM[6]	= new Bgm("/Application/sounds/bgm/Hackbeat.mp3");
			BGM[7]	= new Bgm("/Application/sounds/bgm/Laconic Granny.mp3");
		}
		
		public void SetSFXArray()
		{
			SFX = new Sound[5];
			SFX[0] = new Sound("/Application/sounds/sfx/shoot.wav");
			SFX[1] = new Sound("/Application/sounds/sfx/impact.wav");
			SFX[2] = new Sound("/Application/sounds/sfx/grunt.wav");
			SFX[3] = new Sound("/Application/sounds/sfx/damn.wav");
			SFX[4] = new Sound("/Application/sounds/sfx/fail.wav");
		}
		
		public void SetBGM(int level)
		{	
			if(wasGame)
			{
				gameTime = BGMPlayer.Time;
				wasGame = false;
			}
			if(wasPaused)
			{
				pauseTime = BGMPlayer.Time;
				wasPaused = false;
			}
			
			BGMPlayer.Dispose();
			
			if(level == 0)
			{
				BGMPlayer = BGM[0].CreatePlayer();
			}
			else if(level == 1)
			{
				BGMPlayer = BGM[6].CreatePlayer();
			}
			else if(level == 2)
			{
				BGMPlayer = BGM[1].CreatePlayer();
			}
			else if(level == 3)
			{
				BGMPlayer = BGM[2].CreatePlayer();
			}
			else if(level == 4)
			{
				BGMPlayer = BGM[5].CreatePlayer();
			}
			else if(level == 5 || level == 6)
			{
				if(!inGame)
				{
					if(randomNumber(90) == 0)
					{
						BGMPlayer = BGM[3].CreatePlayer();
						gameSong = 0;
						inGame = true;
					}
					else
					{
						BGMPlayer = BGM[4].CreatePlayer();
						gameSong = 1;
						inGame = true;
					}
				}
				else
				{
					if(gameSong == 0)
					{
						BGMPlayer = BGM[3].CreatePlayer();
						BGMPlayer.Time = gameTime;
					}
					else
					{
						BGMPlayer = BGM[4].CreatePlayer();
						BGMPlayer.Time = gameTime;
					}
				}
				
				wasGame = true;
			}
			else if (level == 7)
			{
				if(!hasPaused)
				{
					if(randomNumber(50) == 0)
					{
						BGMPlayer = BGM[5].CreatePlayer();
						pauseSong = 0;
						hasPaused = true;
					}
					else
					{
						BGMPlayer = BGM[6].CreatePlayer();
						pauseSong = 1;
						hasPaused = true;
					}
				}
				else
				{
					if(pauseSong == 0)
					{
						BGMPlayer = BGM[5].CreatePlayer();
						BGMPlayer.Time = pauseTime;
						
					}
					else
					{
						BGMPlayer = BGM[6].CreatePlayer();
						BGMPlayer.Time = pauseTime;
					}
				}
				
				wasPaused = true;
			}
			else
			{
				BGMPlayer = BGM[7].CreatePlayer();
				
				inGame = false;
				hasPaused = false;
				
				gameTime = 0;
				pauseTime = 0;
			}
					
			PlayBGM();
		}
		
		public void SetSFX(int effect)
		{
			SFXPlayer.Dispose();
			
			SFXPlayer = SFX[effect].CreatePlayer();
			
			PlaySFX();
		}
		
		public void PlayBGM()
		{		
			BGMPlayer.Play();
			
			BGMPlaying = true;
		}
		
		public void StopBGM()
		{
			BGMPlayer.Stop();
			
			BGMPlaying = false;
		}
		 
		public void PlaySFX()
		{
			SFXPlayer.Play();
			
			SFXPlaying = true;
		}
		
		public void StopSFX()
		{
			SFXPlayer.Stop();
			
			SFXPlaying = false;
		}
		
		public int randomNumber(int chance)
		{
			var randGen = new Random(Guid.NewGuid().GetHashCode());
			int randInt = randGen.Next (100);
			
			if (randInt <= chance)
			{
				return 0;	
			}
			else
			{
				return 1;	
			}
		}
		public void Dispose()
		{
			BGMPlayer.Dispose();
		}
	}
}
