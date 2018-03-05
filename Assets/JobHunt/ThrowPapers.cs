using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ThrowPapers : MonoBehaviour {
	public float throwForce, throwTorque;
	public float frequency, adProbability;
	public float startY, startX;
	public int num_newspapers;
	public GameObject ui;

	float timer = 0;
	GameObject newspaperPrefab;
	Sprite[] jobHeadlines;
	Sprite[] otherHeadlines;
	bool started = false;

	// Use this for initialization
	void Start () {
		newspaperPrefab = Resources.Load ("newspaper") as GameObject;
		jobHeadlines = Resources.LoadAll<Sprite>("jobHeadlines");
		otherHeadlines = Resources.LoadAll<Sprite> ("otherHeadlines");
		DialogueBox.Open (201);
	}
	
	// Update is called once per frame
	void Update () {
		if (DialogueBox.isOpen)
			return;
		if (!started) {
			started = true;
			ui.SetActive (true);
		}
		
		timer -= Time.deltaTime;

		if (Newspaper.count < num_newspapers && timer <= 0) {

			timer = 1 / frequency;
			int direction = (Random.value > 0.5) ? 1 : -1;

			Vector3 start = new Vector3 (startX * direction, startY, 0);
			GameObject newspaper = Instantiate(newspaperPrefab, start, Quaternion.identity, transform) as GameObject;
			newspaper.GetComponent<Rigidbody2D> ().AddTorque ((Random.value*2-1) * throwTorque);
			newspaper.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (Random.value*direction, 1) * throwForce);

			bool jobAd = Random.value < adProbability;
			newspaper.GetComponent<SpriteRenderer> ().sprite = jobAd ?
				jobHeadlines [Random.Range (0, jobHeadlines.Length)] :
				otherHeadlines [Random.Range (0, otherHeadlines.Length)];
			newspaper.GetComponent<Newspaper> ().jobAd = jobAd;

		}
		GameObject.FindGameObjectWithTag ("Remaining").GetComponent<UnityEngine.UI.Text> ().text =
			(num_newspapers - Newspaper.count).ToString();

		if (UnityEngine.Camera.main.transform.childCount == 0) {
			GameState gs = GameObject.Find ("GameState").GetComponent<GameState> ();
			gs.jobHuntGame.finish ();
			gs.saveState ();
			if (Newspaper.missed > 0)
				DialogueBox.Open (202);
			else
				DialogueBox.Open (203);
		}
	}
}
