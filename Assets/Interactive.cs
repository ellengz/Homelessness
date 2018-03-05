using UnityEngine;
using System.Collections;

public abstract class Interactive : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown () {
		if (!DialogueBox.isOpen)
			GameObject.FindGameObjectWithTag("Player").GetComponent<Walk> ().Pursue (this.gameObject);
	}

	public abstract void Interact (GameObject other);
}
