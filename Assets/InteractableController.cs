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

	protected BoxCollider2D boxCollider;

	public void OnMouseDown() {
		this.spriteRenderer.sortingLayerName = "Moving";
	}

	public void OnMouseUp() {
		this.spriteRenderer.sortingLayerName = "Foreground";
	}

	// Use this for initialization
	void Start () {
		this.spriteRenderer = this.GetComponent<SpriteRenderer>();
		this.boxCollider = this.GetComponent<BoxCollider2D>();
		if(this.spriteRenderer.sprite == null) {
			this.spriteRenderer.sprite = sprite;
			double initialX = this.spriteRenderer.sprite.bounds.size.x;
			double scaleAdjustment = this.scaleAdjuster / initialX;
			this.transform.localScale = new Vector2((float)scaleAdjustment, (float)scaleAdjustment);

			// @TODO Don't know why 5 works...
			this.boxCollider.size = this.spriteRenderer.bounds.size * 5;
		}
	}

	// Update is called once per frame
	void Update () {

	}
}