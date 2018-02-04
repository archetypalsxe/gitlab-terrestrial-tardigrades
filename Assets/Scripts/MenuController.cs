using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;


public class MenuController : MonoBehaviour {
	// Object that contains the music player script
	public MusicPlayerScript musicPlayer;

	protected SettingsController settings = null;
	protected MuteMusicButton muteMusicButton = null;
	protected bool settingsLoaded = false;
	private static MenuController instance = null;

	public void Update() {
		if(Input.GetKeyDown("m")) {
			this.toggleMusic();
		}
	}

	public void checkToggleButton() {
		Toggle toggle = GameObject.Find("MusicToggle").GetComponent<Toggle>();
		if(toggle.isOn) {
			this.playMusic();
		} else {
			this.stopMusic();
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
				this.playMusic();
			}
			this.setMuteMusicButtonText();
			DontDestroyOnLoad (gameObject);
		}
	}

	public bool isMusicPlaying() {
		this.loadSettings();
		return this.settings.musicPlaying;
	}

	public void playMusic() {
		print("Menu Controller - Play Music");
		this.musicPlayer.startMusic();
		this.updateSettings(true);
	}

	public void stopMusic() {
		print("Menu Controller - Stop Music");
		this.musicPlayer.stopMusic();
		this.updateSettings(false);
	}


	public void toggleMusic() {
		print("Toggling music");
		if(settings.musicPlaying) {
			this.stopMusic();
		} else {
			this.playMusic();
		}
	}

	protected void updateSettings(bool isPlaying) {
		settings.musicPlaying = isPlaying;
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
			if(this.settingsLoaded) {
				return;
			}
			this.settingsLoaded = true;
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
