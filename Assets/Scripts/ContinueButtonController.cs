using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ContinueButtonController : MonoBehaviour {

	public Button yourButton;

	public GlobalContainer globalContainer;

	public Text firstText;
	public Text graveText;

	// Use this for initialization
	void Start () {
		Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
		this.firstText.text = "You Killed "+ this.globalContainer.getTardigradeName();
		this.graveText.text = "Murdered By \"Scientist\" "+ this.globalContainer.getPlayerName();
	}

	// Update is called once per frame
	void Update () {

	}

	public void TaskOnClick() {
		this.globalContainer.setIsTutorial(false);
		SceneManager.LoadScene(
			"Main Level",
			LoadSceneMode.Single
			);
	}
}
