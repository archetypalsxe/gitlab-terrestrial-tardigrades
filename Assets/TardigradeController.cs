using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TardigradeController : MonoBehaviour {

	public SpriteRenderer spriteRenderer;

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

	protected SpriteRenderer redSprite;
	protected float redOpacity = 0f;

	protected SpriteRenderer greenSprite;
	protected float greenOpacity = 0f;

	// Use this for initialization
	void Start () {
		this.fillSensitivity();
		this.debugSensitivity();
		SpriteRenderer[] sprites = GetComponentsInChildren<SpriteRenderer>();
		for(int counter = 0; counter < sprites.Length; counter++) {
			if(sprites[counter].sprite.name.Contains("Red")) {
				this.redSprite = sprites[counter];
				this.redSprite.color = new Color(1f, 1f, 1f, redOpacity);
			}
			if(sprites[counter].sprite.name.Contains("Green")) {
				this.greenSprite = sprites[counter];
				this.greenSprite.color = new Color(1f, 1f, 1f, greenOpacity);
			}
		}

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

	}

	// Make the tardigrade interact with the provided object
	public void interact(GameObject theObject) {
		//InteractableController controller = theObject.GetComponent<InteractableController>();
		redOpacity += 0.1f;
		this.redSprite.color = new Color(1f, 1f, 1f, redOpacity);
	}

	protected void fillSensitivity() {
		for (int type = 1; type <= 2; type++) {
			this.sensitivity[type] = new int[] {-200, -200, -200, -200, -200, -200};
			for (int variant = 1; variant <= 5; variant++) {
				// Switching variant to a min/max
				switch(variant) {
					case 1:
						this.randomizeSensitivity(type, -100, -75);
						break;
					case 2:
						this.randomizeSensitivity(type, -75, -49);
						break;
					case 3:
						this.randomizeSensitivity(type, 50, 50);
						break;
					case 4:
						this.randomizeSensitivity(type, 51, 74);
						break;
					case 5:
						this.randomizeSensitivity(type, 75, 100);
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
