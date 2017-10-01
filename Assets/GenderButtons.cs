using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GenderButtons : MonoBehaviour {

	public Button yourButton;
	public int gender = 0;

	public GlobalContainer globalContainer;

	// Use this for initialization
	void Start () {
		Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	// Update is called once per frame
	void Update () {

	}

	public void TaskOnClick() {
		this.globalContainer.setIsTutorial(false);
		this.globalContainer.setGender(gender);
		SceneManager.LoadScene(
			"Intro",
			LoadSceneMode.Single
			);
	}
}
