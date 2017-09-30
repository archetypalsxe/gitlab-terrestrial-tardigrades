using UnityEngine;
using System.Collections;


public class Draggable : MonoBehaviour {

  private Vector3 offset;

  // Starting X position before moved
  protected float initialX;
  // Starting Y position before moved
  protected float initialY;

  protected Vector3 screenPoint;

  protected Rigidbody2D rigidBody;

  protected Collision2D collision;

  public void start() {
  }

  void OnMouseDown()
  {
      this.initialX = transform.position.x;
      this.initialY = transform.position.y;
      this.rigidBody = gameObject.AddComponent<Rigidbody2D>();
      this.rigidBody.gravityScale = 0;
      this.rigidBody.mass = 1;
      this.rigidBody.angularDrag = 0.05f;
      offset = gameObject.transform.position -
          Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
  }

  void OnMouseDrag()
  {
    TardigradeController tardigrade = GameObject.FindObjectOfType(
       typeof(TardigradeController)
     ) as TardigradeController;
    InteractableController controller = this.gameObject.GetComponent<InteractableController>();

    if(controller.type == 1) {
      if(tardigrade.foodRemaining < 1) {
        return;
      }
    } else {
      if(tardigrade.potionsRemaining < 1) {
        return;
      }
    }
      Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f);
      transform.position = Camera.main.ScreenToWorldPoint(newPosition) + offset;
  }

  void OnMouseUp() {
    if(this.collision != null) {
       TardigradeController tardigrade = GameObject.FindObjectOfType(
          typeof(TardigradeController)
        ) as TardigradeController;
        tardigrade.interact(this.gameObject);
    }
    Destroy(this.rigidBody);
    transform.position = new Vector3(initialX, initialY);
    transform.localEulerAngles = new Vector3(0, 0, 0);
  }

  void OnCollisionEnter2D (Collision2D collision) {
    if(collision.gameObject.CompareTag("tardigrade")) {
      this.collision = collision;
    }
  }

  void OnCollisionExit2D (Collision2D collision) {
    if(collision.gameObject.CompareTag("tardigrade")) {
      this.collision = null;
    }
  }
}