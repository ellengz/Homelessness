using UnityEngine;
using System.Collections;

public class Drive : MonoBehaviour {

	public float speed;
	public int direction = 1;

	private float velocity, size;

	// Use this for initialization
	void Start () {
		Vector3 scale = transform.localScale;
		scale.x = scale.y * direction;
		transform.localScale = scale;

		velocity = speed * direction;
	}

	// Update is called once per frame
	void Update () {
		transform.position += new Vector3 (velocity, 0, 0);
	}
}
