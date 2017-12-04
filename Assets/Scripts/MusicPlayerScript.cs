using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicPlayerScript : MonoBehaviour {

	public AudioClip mainMusic;
	public SettingsController settings;

	protected AudioSource musicSource;

	private static MusicPlayerScript instance = null;

	public void toggleMusic() {
		if(settings.isMusicOn()) {
			this.stopMusic();
		} else {
			this.startMusic();
		}
		this.settings.toggleMusicStatus();
	}

	// Stop the music from playing
	public void stopMusic() {
		musicSource.Stop();
	}

	public void startMusic() {
		musicSource.Play();
	}


	public void Update() {
		if(Input.GetKeyDown("m")) {
			this.toggleMusic();
		}
	}

	void Awake() {
		if(instance != null) {
			Destroy(gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad (gameObject);
			if(this.settings.isMusicOn()) {
				this.musicSource = gameObject.AddComponent<AudioSource>();
				this.musicSource.clip = this.mainMusic;
				musicSource.Play();
				musicSource.loop = true;
			}
		}
	}
}
