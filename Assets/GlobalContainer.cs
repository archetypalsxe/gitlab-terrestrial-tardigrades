using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalContainer : MonoBehaviour {

	public static string tardigradeName = "tartitot";

	public static bool isTutorial = false;

	public static string playerName = "player";

	// 0 = male, 1 = female
	public static int gender = 0;

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

	public void setPlayerName(string name) {
		playerName = name;
	}

	public string getPlayerName() {
		return playerName;
	}

	public void setGender(int localGender) {
		if(localGender > 0) {
			gender = 1;
		} else {
			gender = 0;
		}
	}

	// Returns whether or not we have a male player
	public bool isMale() {
		return gender < 1;
	}
}
