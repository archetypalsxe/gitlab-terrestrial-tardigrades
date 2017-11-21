using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicPlayerScript : MonoBehaviour {

	public AudioClip mainMusic;

	protected AudioSource musicSource;

	private static MusicPlayerScript instance = null;
	private bool musicPlaying = false;

	public bool isMusicPlaying() {
		return this.musicPlaying;
	}

	public void toggleMusic() {
		if(this.musicPlaying) {
			this.stopMusic();
		} else {
			this.startMusic();
		}
		this.musicPlaying = !this.musicPlaying;
	}

	// Stop the music from playing
	public void stopMusic() {
		if(this.musicPlaying) {
			musicSource.Stop();
		}
	}

	public void startMusic() {
		if(!this.musicPlaying) {
			musicSource.Play();
		}
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
			if(!this.musicPlaying) {
				this.musicSource = gameObject.AddComponent<AudioSource>();
				this.musicSource.clip = this.mainMusic;
				musicSource.Play();
				musicSource.loop = true;
				this.musicPlaying = true;
			}
		}
	}
}
