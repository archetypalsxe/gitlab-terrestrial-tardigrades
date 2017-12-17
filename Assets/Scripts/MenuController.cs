using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour {
	// Object that contains the music player script
	public MusicPlayerScript musicPlayer;

	protected SettingsController settings = null;
	protected MuteMusicButton muteMusicButton = null;
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
			instance = this;
			DontDestroyOnLoad (gameObject);
			this.settings = new SettingsController();
			this.musicPlayer.startMusic();
		}
	}

	public bool isMusicPlaying() {
		return settings.musicPlaying;
	}

	public void toggleMusic() {
		if(settings.musicPlaying) {
			this.musicPlayer.stopMusic();
		} else {
			this.musicPlayer.startMusic();
		}
		settings.musicPlaying = !settings.musicPlaying;
		this.searchForMuteMusicButton();
		if(this.muteMusicButton != null) {
			this.muteMusicButton.setText();
		}
	}

	protected void searchForMuteMusicButton() {
		if(this.muteMusicButton != null) {
			return;
		}
		GameObject button = GameObject.FindGameObjectWithTag("toggleMusicButton");
		if(button == null) {
			return;
		}
		this.muteMusicButton = button.GetComponent<MuteMusicButton>();
	}
}
