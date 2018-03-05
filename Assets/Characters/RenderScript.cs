using UnityEngine;
using System.Collections;

public class RenderScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		SpriteRenderer[] children = gameObject.transform.GetComponentsInChildren<SpriteRenderer> ();

		int order = (int)((-transform.position.z+10) * 1000);
		GetComponent<SpriteRenderer> ().sortingOrder = order;

		foreach (SpriteRenderer spriterenderer in children) {
			order--;
			spriterenderer.sortingOrder = order;
		}
	}

}
