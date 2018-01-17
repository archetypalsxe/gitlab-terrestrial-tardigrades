using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenuButton : MonoBehaviour {

	public GameObject settingsPanel;

	// Use this for initialization
	void Start () {
		this.HidePanel();
	}

	void DisplayPanel () {
		this.settingsPanel.SetActive(true);
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
