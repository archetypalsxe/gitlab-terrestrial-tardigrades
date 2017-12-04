using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SettingsController : MonoBehaviour {

	private static SettingsController instance = null;
	private bool musicPlaying = true;

	public bool isMusicOn() {
		return this.musicPlaying;
	}

	public void toggleMusicStatus() {
		this.musicPlaying = !this.musicPlaying;
	}

	void Awake() {
		if(instance != null) {
			Destroy(gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad (gameObject);
		}
	}
}
