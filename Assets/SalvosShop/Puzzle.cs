using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Puzzle : MonoBehaviour {
	public static string blanket;

	public GameObject UI;
	public float time = 120;
	private Sprite[] sprites;
	private GameObject[] pieces;
	private int size;
	private bool loaded = false;

	// Use this for initialization
	void Start () {
		
		DialogueBox.Open (301);
	}

	void LoadPuzzle() {
		sprites = Resources.LoadAll<Sprite> (blanket);
		size = (int)Mathf.Sqrt(sprites.Length);
		pieces = new GameObject[sprites.Length];
		float spread = 8;

		for (int y = 0; y < size; y++) {
			for (int x = 0; x < size; x++) {
				int index = size * x + y;
				GameObject newPiece = new GameObject ();
				newPiece.name = "puzzlepiece" + x.ToString () + '-' + y.ToString ();
				newPiece.transform.parent = transform;
				newPiece.transform.position = new Vector3 (y-size/2, -x, 0);

				newPiece.AddComponent<BoxCollider2D> ();
				newPiece.AddComponent<SpriteRenderer> ().sprite = sprites [index];
				newPiece.AddComponent<PuzzlePiece> ().correctPosition = newPiece.transform.position;

				pieces [index] = newPiece;
			}
		}
		for (int i = 0; i < pieces.Length; i++) {
			pieces [i].transform.position = new Vector3 ((Random.value - 0.5f), (Random.value - 0.5f), 0) * spread;
		}
		loaded = true;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (DialogueBox.isOpen)
			return;
		else if (!loaded) {
			LoadPuzzle ();
		}

		time -= Time.deltaTime;
		UI.SetActive (true);
		UI.transform.Find("time").GetComponent<UnityEngine.UI.Text> ().text = "Time Left: " + ((int)time).ToString () + " seconds.";

		if(time <= 0){
			Debug.Log ("Time out!");
			DialogueBox.Open (304);
		}

		// check the offset from correct position of one puzzle piece
		Vector3 firstOffset = pieces [0].transform.position -
		                      pieces [0].GetComponent<PuzzlePiece> ().correctPosition;
		// check that the offset is the same for all others
		for (int i = 1; i < pieces.Length; i++) {
			Vector3 offset = pieces [i].transform.position -
			                 pieces [i].transform.GetComponent<PuzzlePiece> ().correctPosition;
			
			if (offset != firstOffset)
				return;
		}
		GameObject.Find ("GameState").GetComponent<GameState> ().blanketGame.finish ();
		GameObject.Find ("GameState").GetComponent<GameState> ().saveState ();
		Debug.Log ("Puzzle completed");
		DialogueBox.Open (305);
	}
}
