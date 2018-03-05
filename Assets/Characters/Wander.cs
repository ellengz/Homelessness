using UnityEngine;
using System.Collections;

public class Wander : MonoBehaviour {

	public float walkChance;
	public float walkTimer;

	private float timerValue;
	private Walk walk;

	// Use this for initialization
	void Start () {
		walk = GetComponent<Walk> ();

		// Decide whether to start off walking
		walk.moveSpeed = Random.Range(walk.moveSpeed / 2, walk.moveSpeed);
		if (Random.value < walkChance) {
			walk.target = GetComponentInParent<Street>().RandomStreetLocation ();
		} else {
			walk.target = transform.position;
			timerValue = Random.value * walkTimer;
		}
	
	}
	
	// Update is called once per frame
	void Update () {

		if (transform.position == walk.target) {
			if (timerValue > 0) {
				timerValue = Mathf.Max (0, timerValue - Time.deltaTime);
			} else {
				if (Random.value < walkChance) {
					walk.target = GetComponentInParent<Street> ().RandomStreetLocation ();
				} else
					timerValue = Random.value * walkTimer;
			}
		}
	}
}
