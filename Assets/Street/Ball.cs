using UnityEngine;
using System.Collections;

public class Ball : Interactive {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision) {

	}

	public override void Interact (GameObject other)
	{
		Vector3 f = transform.position - other.transform.position;
		Vector2 f2 = new Vector2 (f.x, f.z);
		f = new Vector3 (f2.x, 0.2f, f2.y) * 50;

		GetComponent<Rigidbody> ().AddForce (f);
	}
}
