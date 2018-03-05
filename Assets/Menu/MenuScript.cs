using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ChangeScene(string sceneName){
		SceneManager.LoadScene(sceneName);
		//Application.LoadLevel(sceneName);
	}
//	public void ChangeImage(GameObject element, string img){
//		element.GetComponents<Image>().
//	}

	public void LinkURL(string url){
		Application.OpenURL (url);
	}
}
