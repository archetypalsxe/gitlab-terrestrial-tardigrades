using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour {

	public Text panelText;

	protected bool doneWithTutorial = false;


	public void updateText(int position) {
		switch (position) {
			case 1:
				this.panelText.text = "Oh no!!! The thing a ma bobs changed to red! You hurt the tardigrade!!! Use another potion to help it!";
				break;
			case 2:
				this.panelText.text = "Whew! That saved him, they're green now! Give him some food now!";
				break;
			case 3:
				this.panelText.text = "That made him even healthier! You're ready to go! Click to continue!";
				this.doneWithTutorial = true;
				break;
		}
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if(doneWithTutorial && Input.anyKey) {
			SceneManager.LoadScene(
				"TitleScreen",
				LoadSceneMode.Single
			);
		}
	}
}
