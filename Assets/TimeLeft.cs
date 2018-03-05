using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class TimeLeft : MonoBehaviour {
	public float time = 120;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		time -= Time.deltaTime;
		gameObject.GetComponent<UnityEngine.UI.Text> ().text = "Time Left: " + ((int)time).ToString () + " seconds.";

		if(time <= 0){
			Debug.Log ("Time out!");
			SceneManager.LoadScene ("street1");
		}
	}
}
