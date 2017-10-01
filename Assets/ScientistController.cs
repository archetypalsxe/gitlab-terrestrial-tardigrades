using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScientistController : MonoBehaviour {

	public GlobalContainer globalContainer;

	// Use this for initialization
	void Start () {
		print(globalContainer.getPlayerName());
		print(globalContainer.isMale());
	}

	// Update is called once per frame
	void Update () {

	}
}
