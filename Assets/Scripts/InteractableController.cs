using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableController : MonoBehaviour {

	public Sprite sprite;

	public double scaleAdjuster = 2;

	/**
		1 = food
		2 = chemical
		3 = device
		*/
	public int type = 1;

	/**
		1 - 5
	*/
	public int variant = 1;

	protected SpriteRenderer spriteRenderer;

	public void OnMouseDown() {
		this.spriteRenderer.sortingLayerName = "Moving";
	}

	public void OnMouseUp() {
		this.spriteRenderer.sortingLayerName = "Moving";
	}

	// Use this for initialization
	void Start () {
		this.spriteRenderer = this.GetComponent<SpriteRenderer>();
	}

	// Update is called once per frame
	void Update () {

	}
}