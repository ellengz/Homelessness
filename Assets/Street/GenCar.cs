using UnityEngine;
using System.Collections;

public class GenCar : MonoBehaviour {
	public GameObject car;
	public float chance, cooldown;
	public Vector3 leftSpawn, rightSpawn;
	private float timer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (timer > 0)
			timer -= Time.deltaTime;
		if (timer < 0)
			timer = 0;
		if (timer == 0) {
			timer = cooldown;
			Instantiate (car, this.transform, this.transform);
			if (Random.value < chance) {
				if (2f * Random.value < chance) {
					// generate car from left
					car.transform.position = leftSpawn;
					car.GetComponent<Drive> ().direction = 1;
				} else {
					// generate car from right
					car.transform.position = rightSpawn;
					car.GetComponent<Drive>().direction = -1;
				}
			}

		}
	}
}
