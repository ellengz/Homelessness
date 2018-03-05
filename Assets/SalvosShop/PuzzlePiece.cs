using UnityEngine;
using System.Collections;

public class PuzzlePiece : MonoBehaviour {
	public Vector3 correctPosition;

	private bool dragged = false;
	private Vector3 holdPosition;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (dragged) {
			transform.position = UnityEngine.Camera.main.ScreenToWorldPoint (Input.mousePosition) - holdPosition;
		}
			
	
	}

	void OnMouseDown() {
		dragged = true;

		holdPosition = UnityEngine.Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position;
	}

	void OnMouseUp() {
		int snappiness = 2;
		dragged = false;
		transform.position = new Vector3 (
			Mathf.Round (transform.position.x * snappiness) / snappiness,
			Mathf.Round (transform.position.y * snappiness) / snappiness,
			0);
	}
}
