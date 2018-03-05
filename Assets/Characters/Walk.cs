using UnityEngine;
using System.Collections;

public class Walk : MonoBehaviour {
	public float moveSpeed;
	public float stepSpeed = 200f;
	public float stepAngle = 0.08f;
	public float personalSpace;
	public bool test;

	public Vector3 target;
	private GameObject targetObject;

	// Use this for initialization
	void Start () {
		if(!test)
			target = transform.position;
		if (test){
			if(GameObject.Find("NPC"))
				targetObject = GameObject.Find("NPC");
			else if(GameObject.Find("SalvosBuilding"))
				targetObject = GameObject.Find("SalvosBuilding");
			else if(GameObject.Find("ball"))
				targetObject = GameObject.Find("ball");
		}
	}
	
	// Update is called once per frame
	void Update () {

		// interact with target if it's within personal space, otherwise keep walking
		if (targetObject) {
			if (Vector3.Distance (targetObject.transform.position, transform.position) < personalSpace) {
				target = transform.position;
				if (targetObject.GetComponent<Interactive> ())
					targetObject.GetComponent<Interactive> ().Interact (this.gameObject);
				targetObject = null;
			} else {
				target = targetObject.transform.position;
			}
		}

		if (transform.position != target) {
			// face the direction of the target
			transform.localScale = new Vector3(
				transform.localScale.y * (transform.position.x < target.x ? -1 : 1),
				transform.localScale.y,
				transform.localScale.z);
			// move entity towards target
			transform.position = Vector3.MoveTowards (transform.position,
				target, moveSpeed * Time.deltaTime);

			// rotate sprite while walking
			if (Mathf.Abs (transform.rotation.z) > stepAngle)
				stepSpeed = -Mathf.Abs (stepSpeed) * Mathf.Sign (transform.rotation.z);
			transform.Rotate (new Vector3 (0, 0, stepSpeed * Time.deltaTime));
		} else {
			transform.rotation = Quaternion.identity;
		}
	}

	public void Pursue (GameObject obj) {
		targetObject = obj;
	}
}
