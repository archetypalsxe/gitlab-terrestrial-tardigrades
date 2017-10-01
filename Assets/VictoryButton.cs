using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VictoryButton : MonoBehaviour {

	public Button yourButton;

	public GlobalContainer globalContainer;

	public Text firstText;
	public Text secondText;

	// Use this for initialization
	void Start () {
		this.firstText.text = "Your research concludes that "+ this.globalContainer.getTardigradeName() +" is a friendly life form. Within 10 years, every family will own a pet tardigrade!";
		this.secondText.text = "Thanks for playing, "+ this.globalContainer.getPlayerName();
		Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	// Update is called once per frame
	void Update () {

	}

	public void TaskOnClick() {
		SceneManager.LoadScene(
			"TitleScreen",
			LoadSceneMode.Single
			);
	}
}
