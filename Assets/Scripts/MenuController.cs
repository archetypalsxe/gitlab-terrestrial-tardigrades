using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

		// Whether or not the music is muted
		public bool isMusicMuted = false;

		// Object that contains the music player script
		public static MusicPlayerScript musicPlayer;
		// Button pressed when they are toggling the music on/off

		public Text toggleMusicButton;

		// When a button is pressed to toggle music
		public void toggleMusic() {
			if(isMusicMuted) {
				this.toggleMusicButton.text = "Stop Music";
			} else {
				this.toggleMusicButton.text = "Play Music";
			}
			this.startStopMusic();
		}

		public void Update() {
			if(Input.GetKeyDown("m")) {
				this.startStopMusic();
			}
		}

		void Awake() {
			print("Awake called");
			DontDestroyOnLoad (musicPlayer);
		}

		protected void startStopMusic() {
			if(isMusicMuted) {
				musicPlayer.startMusic();
			} else {
				musicPlayer.stopMusic();
			}
			this.isMusicMuted = !this.isMusicMuted;
		}
}
