using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroController : MonoBehaviour {

	public GlobalContainer globalContainer;

	public Text prompt;

	public SpriteRenderer shipSprite;
	public SpriteRenderer secondSpriteMale;
	public SpriteRenderer secondSpriteFemale;
	public SpriteRenderer thirdSprite;
	public SpriteRenderer fourthSprite;
	public SpriteRenderer fourthSpriteLayer;

	protected SpriteRenderer secondSprite;

	protected bool doneWithIntro = false;

	protected int position = 0;

	// Use this for initialization
	void Start () {
		this.secondSpriteMale.enabled = false;
		this.secondSpriteFemale.enabled = false;
		this.thirdSprite.enabled = false;
		this.fourthSprite.enabled = false;
		this.fourthSpriteLayer.enabled = false;
		this.prompt.text = "You're aboard the science vessel, SS Tardiship";
		IEnumerator coroutine = this.initialScene();
    StartCoroutine(coroutine);
	}

	// Update is called once per frame
	void Update () {
		switch(position) {
			case 0:
				shipSprite.transform.position = new Vector3(
					(float)(shipSprite.transform.position.x + 0.004),
					(float)(shipSprite.transform.position.y + 0.008),
					0f
				);
				//-1.78 -2
				//1.72 4.74 x = 3.5 y = 6.74
				break;
			case 1:
				//-.38 -1.46
				//.35 4.2 x = .73 y = 5.66
				this.secondSprite.transform.position = new Vector3(
					(float)(secondSprite.transform.position.x + 0.0008),
					(float)(secondSprite.transform.position.y + 0.00672),
					0f
				);
				break;
			case 2:
				this.thirdSprite.transform.position = new Vector3(
					(float)(thirdSprite.transform.position.x),
					(float)(thirdSprite.transform.position.y + 0.0175),
					0f
				);
				//-2.45 -4.82
				//-2.68 3.65 y = 8.47
				break;
			case 3:
				// Purposely left blank, animations instead of panning
				break;
		}
	}

	// Load up the next level to be played
  protected IEnumerator initialScene() {
    yield return new WaitForSeconds(8);
		this.position++;
		IEnumerator coroutine = this.secondScene();
    StartCoroutine(coroutine);
  }

	protected IEnumerator secondScene () {
		this.prompt.text = "Your scans receive signs of life from the planet...";
		this.shipSprite.enabled = false;
		if(globalContainer.isMale()) {
			this.secondSprite = this.secondSpriteMale;
		} else {
			this.secondSprite = this.secondSpriteFemale;
		}
		this.secondSprite.enabled = true;
		yield return new WaitForSeconds(8);
		IEnumerator coroutine = this.thirdScene();
		StartCoroutine(coroutine);
		this.position++;
	}

	protected IEnumerator thirdScene () {
		this.prompt.text = "You have brought a sample onboard to run experiments";
		this.secondSprite.enabled = false;
		this.thirdSprite.enabled = true;
		yield return new WaitForSeconds(8);
		this.position++;
		IEnumerator coroutine = this.fourthScene();
    StartCoroutine(coroutine);
	}

	protected IEnumerator fourthScene() {
		this.thirdSprite.enabled = false;
		this.prompt.text = "You have discovered extra terrestrial life, and it's a tardigrade!";
		this.fourthSprite.enabled = true;
		IEnumerator coroutine = this.fourthLayerFlash();
		StartCoroutine(coroutine);
		yield return new WaitForSeconds(8);
		// So it doesn't keep trying to flash
		this.position++;
		SceneManager.LoadScene(
			"NamingTardigrade",
			LoadSceneMode.Single
		);
	}

	protected IEnumerator fourthLayerFlash () {
		if(this.position != 3) {
			yield return new WaitForSeconds(0);
		} else {
			yield return new WaitForSeconds(0.5f);
			this.fourthSpriteLayer.enabled = !this.fourthSpriteLayer.enabled;
			IEnumerator coroutine = this.fourthLayerFlash();
			StartCoroutine(coroutine);
		}
	}
}