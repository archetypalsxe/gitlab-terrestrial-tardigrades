using UnityEngine;
using System.Collections;


public class Draggable : MonoBehaviour {

    private Vector3 offset;

    void OnMouseDown()
    {
			print("Mouse down");
        offset = gameObject.transform.position -
            Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
    }

    void OnMouseDrag()
    {
			print("Mouse drag");
        Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f);
        transform.position = Camera.main.ScreenToWorldPoint(newPosition) + offset;
    }
}