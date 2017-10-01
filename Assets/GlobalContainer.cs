using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalContainer : MonoBehaviour {

	public static string tardigradeName = "tardigrade";

	public static bool isTutorial = false;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void setTardigradeName(string name) {
		tardigradeName = name;
	}

	public string getTardigradeName() {
		return tardigradeName;
	}

	public void setIsTutorial(bool localBool) {
		isTutorial = localBool;
	}

	public bool getIsTutorial() {
		return isTutorial;
	}
}
