using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

		// Whether or not the music is muted
		public bool isMusicMuted = false;
		public SettingsController settings;

		// Object that contains the music player script
		public MusicPlayerScript musicPlayer;
		// Button pressed when they are toggling the music on/off

		public Text toggleMusicButton;

		public void Update() {
			if(settings.isMusicOn()) {
				this.toggleMusicButton.text = "Stop Music";
			} else {
				this.toggleMusicButton.text = "Play Music";
			}
		}

		void Awake() {
			DontDestroyOnLoad (musicPlayer);
		}
}
