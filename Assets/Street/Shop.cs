using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Shop : Interactive {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void Interact(GameObject other) {
		//transform.GetChild(0).gameObject.SetActive (true);
		SceneManager.LoadScene("SalvosBuilding") ;
		GameObject.Find ("GameState").GetComponent<GameState> ().saveState ();
	}
}
