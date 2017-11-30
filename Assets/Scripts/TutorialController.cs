using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour {

	public Draggable[] potions;
	public Draggable[] food;
	public Text panelText;

	public GlobalContainer globalContainer;

	protected bool doneWithTutorial = false;


	public void updateText(int position) {
		switch (position) {
			case 1:
				this.panelText.text = "Oh no!!! The thing a ma bobs changed to red! You hurt "+ this.globalContainer.getTardigradeName() +"!!! Use another chemical to help it!";
				break;
			case 2:
				foreach (Draggable potion in this.potions) {
					potion.draggable = false;
				}
				foreach (Draggable food in this.food) {
					food.draggable = true;
				}
				this.panelText.text = "Whew! That saved "+ this.globalContainer.getTardigradeName() +", they're green now! Remember, you can only use three chemicals per level! Give him some food now!";
				break;
			case 3:
				this.panelText.text = "That made "+ this.globalContainer.getTardigradeName() +" even healthier! You only have one food per level. You're ready to try for real now! Click to continue!";
				this.doneWithTutorial = true;
				break;
		}
	}

	// Use this for initialization
	void Start () {
		this.panelText.text = "Grab a potion and drag it over to "+
			this.globalContainer.getTardigradeName() +"!!!";
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
