using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NamingPlayer : MonoBehaviour {

	public GlobalContainer globalContainer;

	// Use this for initialization
	void Start () {
		var input = gameObject.GetComponent<InputField>();
		var se = new InputField.SubmitEvent();
		se.AddListener(SubmitName);
		input.onEndEdit = se;
	}

	// Update is called once per frame
	void Update () {

	}

	protected void SubmitName(string name) {
		 this.globalContainer.setPlayerName(name);
		 SceneManager.LoadScene(
 			"GenderSelection",
 			LoadSceneMode.Single
 			);
	}
}