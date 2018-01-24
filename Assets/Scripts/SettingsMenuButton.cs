﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenuButton : MonoBehaviour {

	public GameObject settingsPanel;
	private MenuController menuController = null;
	private Toggle toggleButton = null;

	// Use this for initialization
	void Start () {
		this.HidePanel();
	}

	void DisplayPanel () {
		if(this.menuController == null) {
			GameObject gameObject = GameObject.FindGameObjectWithTag("menuController");
			if(gameObject != null) {
				this.menuController = gameObject.GetComponent<MenuController>();
			} else {
				this.menuController = new MenuController();
			}
		}

		this.settingsPanel.SetActive(true);

		if(this.toggleButton == null) {
			this.toggleButton = GameObject.Find("MusicToggle").GetComponent<Toggle>();
		}

		if(this.toggleButton != null && this.menuController != null) {
			this.toggleButton.isOn = menuController.isMusicPlaying();
		}

		this.settingsPanel.GetComponent<CanvasGroup>().alpha = 1;
	}

	void HidePanel () {
		this.settingsPanel.SetActive(false);
		this.settingsPanel.GetComponent<CanvasGroup>().alpha = 0;
	}

	public void TogglePanel () {
		if(this.settingsPanel.activeSelf) {
			this.HidePanel();
		} else {
			this.DisplayPanel();
		}
	}
}
