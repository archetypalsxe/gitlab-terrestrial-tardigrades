using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {
	// Object that contains the music player script
	public MusicPlayerScript musicPlayer;
	// Button pressed when they are toggling the music on/off
	public Text toggleMusicButton;

	protected SettingsController settings = null;
	private static MenuController instance = null;

	public void Update() {
		if(Input.GetKeyDown("m")) {
			this.toggleMusic();
		}
	}

	public void Awake() {
		if(instance != null) {
			Destroy(gameObject);
		} else {
			print("Continuing");
			instance = this;
			DontDestroyOnLoad (gameObject);
			this.settings = new SettingsController();
			this.musicPlayer.startMusic();
		}
	}

	public void toggleMusic() {
		print("Toggle music called");
		if(settings.musicPlaying) {
			this.musicPlayer.stopMusic();
			if(this.toggleMusicButton != null) {
				this.toggleMusicButton.text = "Play Music";
			}
		} else {
			this.musicPlayer.startMusic();
			if(this.toggleMusicButton != null) {
				this.toggleMusicButton.text = "Stop Music";
			}
		}
		settings.musicPlaying = !settings.musicPlaying;
	}
}
