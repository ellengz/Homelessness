using UnityEngine;
using System.Collections;

public class JobHuntFindScript : MonoBehaviour {

	public bool throwing;
	// Use this for initialization
	void Start () {

		if (DialogueBox.isOpen) {
			DialogueBox.isOpen = false;
			Destroy (GameObject.FindGameObjectWithTag("DialogueBox"));
		}
	}
	
	// Update is called once per frame
	void Update () {

		foreach (var obj in GameObject.FindGameObjectsWithTag("Newspaper")) {
			if (obj.transform.hasChanged) {
				Debug.Log ("The transform has changed!");
				throwing = true;
			} else {
				throwing = false;			
			}
		}
	}

}
