using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicPlayerScript : MonoBehaviour {

	static public bool startAudio = true;
	public GameObject musicPlayer;
	public AudioClip mainMusic;
	public AudioSource musicSource;

	// Stop the music from playing
	public void stopMusic() {
		this.musicSource.Stop();
	}

	public void startMusic() {
		this.musicSource.Play();
	}

	void Awake() {
		if (startAudio) {
			DontDestroyOnLoad (this.musicSource);
			startAudio = false;
			this.musicSource.clip = this.mainMusic;
			this.musicSource.Play();
			this.musicSource.loop = true;
		}
	}
}
