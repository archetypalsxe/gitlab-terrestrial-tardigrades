using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
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

	public void Start() {
		if(instance != null) {
			Destroy(gameObject);
		} else {
			instance = this;
			this.loadSettings();
			this.setMusicPlayer();
			if(this.settings.musicPlaying) {
				this.musicPlayer.startMusic();
			}
			this.setMuteMusicButtonText();
			DontDestroyOnLoad (gameObject);
		}
	}

	public bool isMusicPlaying() {
		print(this.settings);
		return this.settings.musicPlaying;
	}

	public void toggleMusic() {
		if(settings.musicPlaying) {
			this.musicPlayer.stopMusic();
		} else {
			this.musicPlayer.startMusic();
		}
		settings.musicPlaying = !settings.musicPlaying;
		this.saveSettings();
		this.setMuteMusicButtonText();
	}

	protected void setMusicPlayer() {
		if(this.musicPlayer == null) {
			this.musicPlayer = GameObject.Find("Music Player").GetComponent<MusicPlayerScript>();
		}
	}

	protected void setMuteMusicButtonText() {
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


		protected void saveSettings() {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Create (Application.persistentDataPath + "/settings.gd");
			bf.Serialize(file, this.settings);
			file.Close();
		}

		protected void loadSettings() {
			if(File.Exists(Application.persistentDataPath + "/settings.gd")) {
				BinaryFormatter bf = new BinaryFormatter();
				FileStream file = File.Open(Application.persistentDataPath + "/settings.gd", FileMode.Open);
				this.settings = (SettingsController)bf.Deserialize(file);
				file.Close();
			} else {
				this.settings = new SettingsController();
			}
		}

}
