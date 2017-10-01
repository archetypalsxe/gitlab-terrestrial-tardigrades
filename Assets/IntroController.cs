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
	protected SpriteRenderer secondSprite;

	protected bool doneWithIntro = false;

	protected int position = 0;

	// Use this for initialization
	void Start () {
		this.secondSpriteMale.enabled = false;
		this.secondSpriteFemale.enabled = false;
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
				break;
			case 3:
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
		this.position++;
		SceneManager.LoadScene(
			"NamingTardigrade",
			LoadSceneMode.Single
		);
	}
}