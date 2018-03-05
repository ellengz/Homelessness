using UnityEngine;
using System.Collections;

public class SalvosBuildingScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject.Find ("GameState").GetComponent<GameState> ().loadState ();
	}

	
	// Update is called once per frame
	void Update () {
	
	}

	public void TalkToAssistant(){
		DialogueBox.Open (111);
	}
}
