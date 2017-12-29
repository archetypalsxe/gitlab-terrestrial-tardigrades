using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicPlayerScript : MonoBehaviour {

	public AudioClip mainMusic;

	protected AudioSource musicSource;
	private static MusicPlayerScript instance = null;

	// Stop the music from playing
	public void stopMusic() {
		musicSource.Stop();
	}

	public void startMusic() {
		musicSource.Play();
	}

	public void Awake() {
		if(instance != null) {
			Destroy(gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad (gameObject);
			this.musicSource = gameObject.AddComponent<AudioSource>();
			this.musicSource.clip = this.mainMusic;
			musicSource.loop = true;
				// musicSource.Play();
		}
	}
}
