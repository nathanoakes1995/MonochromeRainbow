using System;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Audio;

namespace MonochromeRainbow
{
	public class AudioManager
	{
		private BgmPlayer	BGMPlayer;
		private BgmPlayer	BGMAuxPlayer;
  		private Bgm[]		BGM;
		
		public int	gameSong;
		public int	pauseSong;
		public bool	BGMPlaying;
		public bool inGame;
		public bool hasPaused;
		
		public AudioManager()
		{
			SetBGMArray();
			
			BGMPlayer =		BGM[0].CreatePlayer();
			BGMAuxPlayer =	BGM[1].CreatePlayer();
			
			BGMPlayer.Loop = true;
			BGMAuxPlayer.Loop = true;
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
			BGM[7]	= new Bgm("/Application/sounds/bgm/One Sly Move.mp3");
		}
		
		public void SetSFXArray()
		{
		}
		
		public void SetBGM(int level)
		{	
			if(level == 0)
			{
				BGMPlayer.Dispose();
				BGMPlayer = BGM[0].CreatePlayer();
				
				PlayBGM();
			}
			else if(level == 1)
			{
				BGMPlayer.Dispose();
				BGMPlayer = BGM[6].CreatePlayer();
				
				PlayBGM();
			}
			else if(level == 2)
			{
				BGMPlayer.Dispose();
				BGMPlayer = BGM[1].CreatePlayer();
				
				PlayBGM();
			}
			else if(level == 3)
			{
				BGMPlayer.Dispose();
				BGMPlayer = BGM[2].CreatePlayer();
				
				PlayBGM();
			}
			else if(level == 4)
			{
				BGMPlayer.Dispose();
				BGMPlayer = BGM[5].CreatePlayer();
				
				PlayBGM();
			}
			else if(level == 5 || level == 6)
			{
				BGMAuxPlayer.Pause();
				
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
					}
					else
					{
						BGMPlayer = BGM[4].CreatePlayer();
					}
				}
				
				if (BGMPlayer.Status == BgmStatus.Paused)
				{
					BGMPlayer.Resume();
				}
				else
				{
					PlayBGM();
				}
			}
			else if (level == 7)
			{
				BGMPlayer.Pause();
				
				if(!hasPaused)
				{
					if(randomNumber(50) == 0)
					{
						BGMAuxPlayer = BGM[5].CreatePlayer();
						pauseSong = 0;
						hasPaused = true;
					}
					else
					{
						BGMAuxPlayer = BGM[6].CreatePlayer();
						pauseSong = 1;
						hasPaused = true;
					}
				}
				else
				{
					if(pauseSong == 0)
					{
						BGMAuxPlayer = BGM[5].CreatePlayer();
					}
					else
					{
						BGMAuxPlayer = BGM[6].CreatePlayer();
					}
				}
				
				if (BGMAuxPlayer.Status == BgmStatus.Paused)
				{
					BGMAuxPlayer.Resume();
				}
				else
				{
					BGMAuxPlayer.Play();
			
					BGMPlaying = true;
				}
			}
			else
			{
				BGMPlayer = BGM[7].CreatePlayer();
				
				inGame = false;
				hasPaused = false;
				
				PlayBGM();
			}
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
