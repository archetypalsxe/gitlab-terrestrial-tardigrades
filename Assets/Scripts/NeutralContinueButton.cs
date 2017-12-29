using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NeutralContinueButton : MonoBehaviour {

	public Button yourButton;

	public GlobalContainer globalContainer;

	public Text firstText;

	// Use this for initialization
	void Start () {
		Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
		this.firstText.text = " "+ this.globalContainer.getTardigradeName();
		this.firstText.text = this.globalContainer.getTardigradeName() +" turned violent, and you were forced to release them into space. Their fate is unknown";
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
