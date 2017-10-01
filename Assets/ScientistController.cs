using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScientistController : MonoBehaviour {

	public GlobalContainer globalContainer;
	public SpriteRenderer pulsingBackground;
	public float flashRate = 0f;

	protected float opacity = 0f;
	protected bool flashAscending = true;

	// Use this for initialization
	void Start () {
		print(globalContainer.getPlayerName());
		print(globalContainer.isMale());
	}

	// Update is called once per frame
	void Update () {
		pulsingBackground.color = new Color(1f, 1f, 1f, this.opacity);
		if(this.opacity >= 0.85) {
			this.flashAscending = false;
		} else if (this.opacity < 0.15f) {
			this.flashAscending = true;
		}
		if(this.flashAscending) {
			this.opacity += this.flashRate;
		} else {
			this.opacity -= this.flashRate;
		}
	}
}
