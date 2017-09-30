using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TardigradeController : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	// Make the tardigrade interact with the provided object
	public void interact(GameObject theObject) {
		print ("Interacting");
		InteractableController controller = theObject.GetComponent<InteractableController>();
		print(controller);
		print(controller.type);
		print(controller.variant);

	}
}
