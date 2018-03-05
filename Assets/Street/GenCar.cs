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
			// generate car from left
			if (Random.value < chance) {
				Instantiate (car);
				car.transform.position = leftSpawn;
				//OtherScript otherScript = GetComponent<OtherScript>();
				car.GetComponent<Drive>().direction = 1;
			}
			// generate car from right
			if (Random.value < chance) {
				Instantiate (car);
				car.transform.position = rightSpawn;
				car.GetComponent<Drive>().direction = -1;
			}
		}
	}
}
