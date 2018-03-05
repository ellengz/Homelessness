using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NPC : Interactive {
	public Sprite[] sprites;
	private static int count = 0;

	public int id = 0;

	// Use this for initialization
	void Start () {
		gameObject.AddComponent<RenderScript> ();
		// set random sprites for generic NPCs
		if (id == 0) {
			//GetComponent<SpriteRenderer> ().sprite = sprites [count++ % sprites.Length];
		}
	}
	
	// Update is called once per frame
	void Update () {
//		SpriteRenderer[] children = gameObject.transform.GetComponentsInChildren<SpriteRenderer> ();
//
//		int order = (int)((-transform.position.z+10) * 1000);
//		GetComponent<SpriteRenderer> ().sortingOrder = order;
//
//		foreach (SpriteRenderer spriterenderer in children) {
//			order--;
//			spriterenderer.sortingOrder = order;
//		}
//			GetComponentInChildren<SpriteRenderer> ().sortingOrder = 
//		gameObject.GetComponentInChildren<GameObject>("npcBody").GetComponentInChildren<SpriteRenderer> ().sortingOrder = gameObject.transform.position.z;
//		gameObject.GetComponentInChildren<GameObject>("npc").GetComponentInChildren<SpriteRenderer> ().sortingOrder = gameObject.transform.position.z;
		
	}

	public override void Interact(GameObject other) {
		GetComponent<Walk> ().target = transform.position;
		DialogueBox.Open (id == 0 ? Narrative.RandomGreeting() : id);
	}


	void OnCollisionEnter(Collision collision) {
		if (collision.collider.GetComponent<Ball> ())
			GetComponent<Walk> ().Pursue (collision.collider.gameObject);
		if (collision.collider.GetComponent<NPC>())
			GetComponent<Walk>().target = GetComponentInParent<Street>().RandomStreetLocation ();
	}

}
