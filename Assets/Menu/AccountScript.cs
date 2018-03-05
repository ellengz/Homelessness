using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AccountScript : MonoBehaviour {
	PlayerAccountScript playerAccountScript;

	// Use this for initialization
	void Start () {
		playerAccountScript = GameObject.Find ("Player").GetComponent<PlayerAccountScript> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ChangePlayerName(){
		GameObject.Find("Player").GetComponent<PlayerAccountScript>().playerInfo.name =
			GameObject.Find ("NameInputField").GetComponent<InputField> ().text;
	}

	public void ChangePlayerSex(){
		GameObject.Find ("Player").GetComponent<PlayerAccountScript> ().playerInfo.sex =
				GameObject.Find ("Dropdown").GetComponent<Dropdown>().value==0 ? "girl" : "boy";
		playerAccountScript.ReloadSprite ();
	}

	public void ChangeHairValue() {
		playerAccountScript.playerInfo.hair =
			(int)GameObject.Find ("HairSlider").GetComponent<Slider> ().value;
		playerAccountScript.ReloadSprite ();
	}

	public void ChangeBodyValue() {
		playerAccountScript.playerInfo.body =
			(int)GameObject.Find ("ClothesSlider").GetComponent<Slider> ().value;
		playerAccountScript.ReloadSprite ();
	}
}
