using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class TardigradeController : MonoBehaviour {

	public bool isTutorial = false;
	public bool haveMicroscope = true;
	public Text warningText;
	public bool textHidden = false;

	public SpriteRenderer spriteRenderer;
	public SpriteRenderer microscope;
	public GameObject nextState;

	/**
	  [type] => [variant] => percentage
		1=>
			1 => 75
			2 => 50
			3 => 2
			4 => 51
			5 => 48
		2=>
			1 => 88
	*/
	protected int[][] sensitivity = new int[3][];

	protected static SpriteRenderer redSprite;
	protected static SpriteRenderer greenSprite;

	// Health of the tardigrade from -100 to 100
	protected static float opacity = 0f;

	public int potionsRemaining = 3;
	public int foodRemaining = 1;

	protected int tutorialPosition = 0;

	// Use this for initialization
	void Start () {
		if(this.warningText != null) {
			this.warningText.enabled = false;
		}
		this.fillSensitivity();
		//this.debugSensitivity();
		SpriteRenderer[] sprites = GetComponentsInChildren<SpriteRenderer>();
		for(int counter = 0; counter < sprites.Length; counter++) {
			if(sprites[counter].sprite.name.Contains("Red")) {
				redSprite = sprites[counter];
				redSprite.color = new Color(1f, 1f, 1f, 0f);
			}
			if(sprites[counter].sprite.name.Contains("Green")) {
				greenSprite = sprites[counter];
				greenSprite.color = new Color(1f, 1f, 1f, 0f);
			}
		}

	}

	public void onEnable() {
		if(this.warningText != null) {
			this.warningText.enabled = false;
		}
	}

	// Set opacity back to 0
	public void resetOpacity() {
		opacity = 0f;
	}

	// Print out the sensitivity
	public void debugSensitivity() {
		for(int type = 1; type <= 2; type++) {
			for(int variant = 1; variant <= 5; variant++) {
				print("Type: "+ type + " Variant: "+ variant +" "+this.sensitivity[type][variant]);
			}
		}
	}

	// Update is called once per frame
	void Update () {
		if(!this.textHidden && this.warningText != null) {
			this.textHidden = true;
			this.warningText.enabled = false;
		}
		if(redSprite != null && greenSprite != null) {
			if(opacity > 0) {
				redSprite.color = new Color(1f, 1f, 1f, 0f);
				greenSprite.color = new Color(1f, 1f, 1f, (float)opacity / 100);
			} else {
				redSprite.color = new Color(1f, 1f, 1f, Mathf.Abs(opacity) / 100);
				greenSprite.color = new Color(1f, 1f, 1f, 0);
			}
		}
	}

	// Make the tardigrade interact with the provided object
	public void interact(GameObject theObject) {
		if(this.isTutorial) {
			this.tutorialInteract(theObject);
		} else {
			this.normalInteract(theObject);
		}
	}

	public void tutorialInteract(GameObject theObject) {
		switch (this.tutorialPosition) {
			case 0:
				opacity = -80f;
				break;
			case 1:
				opacity = 20f;
				break;
			case 2:
				opacity = 80f;
				break;
		}

		if(opacity > 0) {
			this.setGreenColor(new Color(1f, 1f, 1f, (float)opacity / 100));
		} else {
			this.setRedColor(new Color(1f, 1f, 1f, Mathf.Abs(opacity) / 100));
		}
		this.tutorialPosition++;
		TutorialController controller = GameObject.FindObjectOfType(
			typeof(TutorialController)
		) as TutorialController;
		controller.updateText(this.tutorialPosition);

	}

	public void normalInteract(GameObject theObject) {
		InteractableController controller = theObject.GetComponent<InteractableController>();
		int sensitivity = this.sensitivity[controller.type][controller.variant];
		opacity += sensitivity / 2;
		if(opacity > 100) {
			opacity = 100;
		}
		print("Opacity: "+ opacity);
		if(opacity <= -100) {
			opacity = 0f;
			SceneManager.LoadScene(
				"DeathScreen",
				LoadSceneMode.Single
			);
		}

		if(opacity > 0) {
			this.setGreenColor(new Color(1f, 1f, 1f, (float)opacity / 100));
		} else {
			this.setRedColor(new Color(1f, 1f, 1f, Mathf.Abs(opacity) / 100));
		}
		if(controller.type == 1) {
			this.foodRemaining--;
		} else {
			this.potionsRemaining--;
		}
		if(this.foodRemaining < 1 && this.potionsRemaining < 1) {
			this.nextLevel();
		}
	}

	public void OnEnable() {
		if(this.microscope != null) {
			if(this.haveMicroscope) {
				this.microscope.enabled = true;
			} else {
				this.microscope.enabled = false;
			}
		}
	}

	// Hide any chemical/food errors that might be visible
	public void clearErrors() {
		this.warningText.enabled = false;
	}

	// Display an error that they are trying to use unavailable food
	public void displayFoodError() {
		this.warningText.text = "You Can Only Use Food Once Per Level. Use a Chemical!";
		this.warningText.enabled = true;
	}

	// Display an error that they are trying to use unavailable chemical
	public void displayChemicalError() {
		this.warningText.text = "You Can Only Use Three Chemicals Per Level. Use some food!";
		this.warningText.enabled = true;
	}

	protected void nextLevel() {
		if(this.nextState != null) {
			this.nextState.SetActive(true);
			this.gameObject.SetActive(false);
		} else {
			if(opacity >= 75) {
				opacity = 0f;
				SceneManager.LoadScene(
	        "VictoryScreen",
	        LoadSceneMode.Single
	    	);
			} else {
				opacity = 0f;
				SceneManager.LoadScene(
	        "NeutralEnding",
	        LoadSceneMode.Single
	    	);
			}
		}
	}

	protected void fillSensitivity() {
		for (int type = 1; type <= 2; type++) {
			this.sensitivity[type] = new int[] {-200, -200, -200, -200, -200, -200};
			for (int variant = 1; variant <= 5; variant++) {
				// Switching variant to a min/max
				switch(variant) {
					case 1:
						this.randomizeSensitivity(type, -100, -50);
						break;
					case 2:
						this.randomizeSensitivity(type, -50, 0);
						break;
					case 3:
						this.randomizeSensitivity(type, 0, 0);
						break;
					case 4:
						this.randomizeSensitivity(type, 0, 50);
						break;
					case 5:
						this.randomizeSensitivity(type, 50, 100);
						break;
				}
			}
		}
		this.sensitivity[1][5] = -500;
	}

	protected void randomizeSensitivity(int type, int min, int max) {
		bool shouldContinue = true;
		do {
			int randomInt = Random.Range(1,6);
			if(this.sensitivity[type][randomInt] < -100) {
				this.sensitivity[type][randomInt] = Random.Range(min, max);
				shouldContinue = false;
			}
		} while (shouldContinue);
	}

	protected void setRedColor(Color color) {
		redSprite.color = color;
		greenSprite.color = new Color(1f, 1f, 1f, 0f);
	}

	protected void setGreenColor(Color color) {
		greenSprite.color = color;
		redSprite.color = new Color(1f, 1f, 1f, 0);
	}

}
