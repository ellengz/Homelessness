using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;


public class DialogueBox : MonoBehaviour {
	private static GameObject DialogueBoxPrefab, ButtonPrefab;
	public static bool isOpen = false;
	public static int id;

	public void SwitchScene(string name) {
		isOpen = false;
		Destroy (gameObject);
		SceneManager.LoadScene (name);
	}

	public void SetContents(int newId) {
		int[] terminal = { 0, 100, 200, 300, 302, 303, 107, 108 };

		GameState gs = GameObject.Find ("GameState").GetComponent<GameState> ();
		id = newId;
		if (id == 100) SwitchScene ("street1");
		if (id == 300) SwitchScene ("ClothShop");
		if (id == 200) SwitchScene ("JobHunt");
		if (id == 302) Puzzle.blanket = "blanket";
		if (id == 303) Puzzle.blanket = "salvos_blanket";
		if (id == 107) {
			gs.blanketGame.unlock ();
			Debug.Log ("blanketGame unlocked: "+ gs.blanketGame.isUnlocked());
			gs.saveState ();
		}
		if (id == 108) {
			gs.jobHuntGame.unlock ();
			Debug.Log ("jobHuntGame unlocked: "+ gs.jobHuntGame.isUnlocked());
			gs.saveState ();

		}

		if (terminal.Contains(id)) {
			isOpen = false;
			Destroy (gameObject);
			return;
		}

		if (!Narrative.dialogueIndex.ContainsKey(id)) {
			Debug.Log("Error: dialogueId "+id.ToString()+" not found.");
			Destroy (gameObject);
			return;
		}

		Dialogue dialogue = Narrative.dialogueIndex [id];
		GetComponentInChildren<Text> ().text = dialogue.message;
		GameObject responsesBox = transform.Find ("Responses").gameObject;

		// clear any previous responses
		for (int i = 0; i < responsesBox.transform.childCount; i++) {
			Destroy (responsesBox.transform.GetChild (i).gameObject);
		}

		// load new responses
		foreach(KeyValuePair<int, string> response in dialogue.responses){
			int target = response.Key;
			if (target == 112){
				Debug.Log ("blanket game unlocked: " + gs.blanketGame.isUnlocked());
				if (!gs.blanketGame.isUnlocked ()) {
					continue;
				}
			}
			if (target == 114) {
				if (!gs.jobHuntGame.isUnlocked ()) {
					continue;
				}
			}
			if (target == 102 && gs.blanketGame.isUnlocked ())
				continue;
			if (target == 109 && (!gs.blanketGame.isfinished () || gs.jobHuntGame.isUnlocked()))
				continue;
			if (target == 220 && !gs.jobHuntGame.isfinished ())
				continue;

			GameObject button = Instantiate (ButtonPrefab) as GameObject;

			button.transform.SetParent (responsesBox.transform, false);

			button.GetComponentInChildren<Text> ().text = response.Value;
			button.GetComponent<Button>().onClick.AddListener(delegate { SetContents (target); });
		}
	}

	public static void Open(int id) {
		if (isOpen)
			return;
		isOpen = true;
		DialogueBoxPrefab = Resources.Load ("DialogueBox") as GameObject;
		ButtonPrefab = Resources.Load ("Button") as GameObject;
		
		GameObject camera = GameObject.FindGameObjectWithTag ("MainCamera");
		Vector3 pos = camera.transform.position + new Vector3 (0, 1.5f, 10);
		GameObject newDialogue = Instantiate (DialogueBoxPrefab, pos, Quaternion.identity, camera.transform) as GameObject;

		newDialogue.GetComponent<DialogueBox>().SetContents (id);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
