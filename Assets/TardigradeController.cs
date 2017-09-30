using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TardigradeController : MonoBehaviour {

	public SpriteRenderer spriteRenderer;

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
	protected static float opacity = 0f;

	public int potionsRemaining = 3;
	public int foodRemaining = 1;

	// Use this for initialization
	void Start () {
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

	public void OnEnable() {

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
		if(opacity > 0) {
			redSprite.color = new Color(1f, 1f, 1f, 0f);
			greenSprite.color = new Color(1f, 1f, 1f, (float)opacity / 100);
		} else {
			redSprite.color = new Color(1f, 1f, 1f, Mathf.Abs(opacity) / 100);
			greenSprite.color = new Color(1f, 1f, 1f, 0);
		}
	}

	// Make the tardigrade interact with the provided object
	public void interact(GameObject theObject) {
		InteractableController controller = theObject.GetComponent<InteractableController>();
		int sensitivity = this.sensitivity[controller.type][controller.variant];
		opacity += sensitivity / 2;
		print("Opacity: "+ opacity);

		if(opacity > 0) {
			redSprite.color = new Color(1f, 1f, 1f, 0f);
			greenSprite.color = new Color(1f, 1f, 1f, (float)opacity / 100);
		} else {
			redSprite.color = new Color(1f, 1f, 1f, Mathf.Abs(opacity) / 100);
			greenSprite.color = new Color(1f, 1f, 1f, 0);
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

	protected void nextLevel() {
		if(this.nextState != null) {
			this.nextState.SetActive(true);
			this.gameObject.SetActive(false);
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


}
