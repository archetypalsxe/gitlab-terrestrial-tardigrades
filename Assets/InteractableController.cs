using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableController : MonoBehaviour {

	public Sprite sprite;

	protected SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
		this.spriteRenderer = GetComponent<SpriteRenderer>();
		if(this.spriteRenderer.sprite == null) {
			this.spriteRenderer.sprite = sprite;
			transform.localScale = new Vector3(0.1f, 0.1f, 0f);
		}
	}

	// Update is called once per frame
	void Update () {

	}
}
