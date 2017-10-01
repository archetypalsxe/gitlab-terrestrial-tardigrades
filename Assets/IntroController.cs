using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroController : MonoBehaviour {

	public GlobalContainer globalContainer;

	public Text prompt;

	protected bool doneWithIntro = false;

	// Use this for initialization
	void Start () {
		IEnumerator coroutine = this.waitForEffect();
    StartCoroutine(coroutine);
		this.prompt.enabled = false;
	}

	// Update is called once per frame
	void Update () {
		if(doneWithIntro && Input.anyKey) {
			SceneManager.LoadScene(
				"NamingTardigrade",
				LoadSceneMode.Single
			);
		}
	}

	// Load up the next level to be played
  protected IEnumerator waitForEffect() {
    yield return new WaitForSeconds(5);
		this.prompt.enabled = true;
		this.doneWithIntro = true;
  }
}