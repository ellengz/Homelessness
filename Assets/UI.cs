using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour {

	public void LoadScene (string Destination) {
		SceneManager.LoadScene (Destination);
	}
}