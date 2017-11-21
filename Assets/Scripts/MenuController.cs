using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

		// Whether or not the music is muted
		public bool isMusicMuted = false;

		// Object that contains the music player script
		public MusicPlayerScript musicPlayer;
		// Button pressed when they are toggling the music on/off

		public Text toggleMusicButton;

		public void Update() {
			if(musicPlayer.isMusicPlaying()) {
				this.toggleMusicButton.text = "Stop Music";
			} else {
				this.toggleMusicButton.text = "Play Music";
			}
		}

		public void toggleMusic() {
			this.musicPlayer.toggleMusic();
		}

		void Awake() {
			print("Awake called");
			DontDestroyOnLoad (musicPlayer);
		}
}
