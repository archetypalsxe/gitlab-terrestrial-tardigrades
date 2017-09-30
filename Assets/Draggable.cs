using UnityEngine;
using System.Collections;


public class Draggable : MonoBehaviour {

  private Vector3 offset;

  // Starting X position before moved
  protected float initialX;
  // Starting Y position before moved
  protected float initialY;

  protected Vector3 screenPoint;

  public void start() {
  }

  void OnMouseDown()
  {
      this.initialX = transform.position.x;
      this.initialY = transform.position.y;
      offset = gameObject.transform.position -
          Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
  }

  void OnMouseDrag()
  {
      Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f);
      transform.position = Camera.main.ScreenToWorldPoint(newPosition) + offset;
  }

  void OnMouseUp() {
    transform.position = new Vector3(initialX, initialY);
    transform.localEulerAngles = new Vector3(0, 0, 0);
  }

  void OnCollisionEnter2D (Collision2D collision) {
  }
}