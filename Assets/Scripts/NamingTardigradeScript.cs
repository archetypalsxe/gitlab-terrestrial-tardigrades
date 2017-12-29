using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NamingTardigradeScript : MonoBehaviour {

	public GlobalContainer globalContainer;

	public SpriteRenderer wiggles;

	protected bool wiggleEnabled = true;

	// Use this for initialization
	void Start () {
		IEnumerator coroutine = this.wiggle();
		StartCoroutine(coroutine);
		var input = gameObject.GetComponent<InputField>();
		var se = new InputField.SubmitEvent();
		se.AddListener(SubmitName);
		input.onEndEdit = se;
	}

	// Update is called once per frame
	void Update () {

	}

	protected IEnumerator wiggle() {
		if(!this.wiggleEnabled) {
			yield return new WaitForSeconds(0f);
		} else {
			yield return new WaitForSeconds(0.5f);
			this.wiggles.enabled = !this.wiggles.enabled;
			IEnumerator coroutine = this.wiggle();
			StartCoroutine(coroutine);
		}
	}

	protected void SubmitName(string name) {
		this.wiggleEnabled = false;
		 this.globalContainer.setTardigradeName(name);
		 if(this.globalContainer.getIsTutorial()) {
			 SceneManager.LoadScene(
	 			"Tutorial",
	 			LoadSceneMode.Single
	 			);
		 } else {
			 SceneManager.LoadScene(
	 			"Main Level",
	 			LoadSceneMode.Single
	 			);
		 }
	}
}
