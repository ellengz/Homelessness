using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Newspaper : MonoBehaviour {
	public bool jobAd = false;
	public bool test = false;
	bool alreadyClicked = false;
	int layer;

	public static int count = 0;
	static int score = 0;
	public static int missed = 0;

	// Use this for initialization
	void Start () {
		layer = GetComponent<SpriteRenderer> ().sortingOrder = (count++) * 2;
	}

	// Update is called once per frame
	void Update () {
		if (test) {
			OnMouseDown ();
			return;
		}

		if (transform.position.y < UnityEngine.Camera.main.GetComponent<ThrowPapers> ().startY) {
			if (jobAd && !alreadyClicked) {
				missed++;
				GameObject.FindGameObjectWithTag ("Missed").GetComponent<UnityEngine.UI.Text> ().text = missed.ToString ();
			}
			Destroy (gameObject);
		}
		if(score < 0) {
			Debug.Log ("Negative score!");
			SceneManager.LoadScene ("street1");
		}
	}

	void OnMouseDown() {
		if (alreadyClicked)
			return;
		alreadyClicked = true;

		GameObject mark;
		if (jobAd) {
			score++;
			mark = Instantiate (Resources.Load ("circlePrefab"), transform) as GameObject;
		} else {
			score--;
			mark = Instantiate (Resources.Load ("crossPrefab"), transform) as GameObject;
		}

		mark.transform.localPosition = Vector3.zero;
		mark.transform.localRotation = Quaternion.identity;
		mark.GetComponent<SpriteRenderer> ().sortingOrder = layer + 1;
		GameObject.FindGameObjectWithTag ("Score").GetComponent<UnityEngine.UI.Text> ().text = score.ToString ();
	}

}
