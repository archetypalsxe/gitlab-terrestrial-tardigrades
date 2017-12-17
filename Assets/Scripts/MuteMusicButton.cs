using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteMusicButton : MonoBehaviour {

	// Button pressed when they are toggling the music on/off
	public Text toggleMusicButton;

	private MenuController menuController = null;

	public void Start() {
		this.setText();
	}

	public void toggleMusic() {
		this.findMenuController();
		this.menuController.toggleMusic();
	}

	public void setText() {
		this.findMenuController();
		if(this.menuController.isMusicPlaying()) {
			this.toggleMusicButton.text = "Stop Music";
		} else {
			this.toggleMusicButton.text = "Play Music";
		}
	}

	protected void findMenuController() {
		if(this.menuController == null) {
			this.menuController = GameObject.FindGameObjectWithTag("menuController").GetComponent<MenuController>();
		}
	}
}
