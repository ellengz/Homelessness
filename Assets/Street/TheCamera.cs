using UnityEngine;
using System.Collections;

public class TheCamera : MonoBehaviour {

	public GameObject player;
	public float minX, maxX;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;
		pos.x = Mathf.Clamp (player.transform.position.x, minX, maxX);
		transform.position = pos;
	}
}
