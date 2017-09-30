using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableController : MonoBehaviour {

	public Sprite sprite;

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
			double scaleAdjustment = (double)2 / initialX;
			this.transform.localScale = new Vector2((float)scaleAdjustment, (float)scaleAdjustment);

			// @TODO Don't know why 5 works...
			this.boxCollider.size = this.spriteRenderer.bounds.size * 5;
		}
	}

	// Update is called once per frame
	void Update () {

	}
}