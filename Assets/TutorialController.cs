using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour {

	public Text panelText;

	public void updateText(int position) {
		switch (position) {
			case 1:
				this.panelText.text = "Oh no!!! The thing a ma bobs changed to red! You hurt the tardigrade!!! Use another potion to help it!";
				break;
			case 2:
				this.panelText.text = "Whew! That saved him, they're green now! Give him some food now!";
				break;
			case 3:
				this.panelText.text = "That made him even healthier! You're ready to go! Press any key to continue!";
				break;
		}
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}
