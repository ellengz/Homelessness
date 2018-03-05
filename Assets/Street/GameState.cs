using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour {

	public bool Blanket = false;
	public bool test = false;

	public class MiniGame {
		
		public string gameName = null;
		public bool unlocked = false;
		public bool finished = false;
		public int highestScore = 0;

		public MiniGame(string gameName){
			this.gameName = gameName;
		}

		public void unlock(){
			unlocked = true;
		}

		public void finish(){
			finished = true;
		}

		public void setHighestScore(int highestScore){
			this.highestScore = highestScore;
		}

		public bool isUnlocked(){
			return unlocked;
		}

		public bool isfinished(){
			return finished;
		}

	}

	public MiniGame blanketGame = null;
	public MiniGame jobHuntGame = null;
	public MiniGame foodGame = null;

	public const string BlanketGame = "blanket game";
	public const string JobHuntGame = "job hunt game";
	public const string FoodGame = "food game";

	private Vector3 player_pos = Vector3.zero;

	// Use this for initialization
	void Start () {
		loadState ();
	}
	
	// Update is called once per frame
	void Update () {
		if (test)
			Blanket = GameObject.Find ("GameState").GetComponent<GameState> ().blanketGame.isUnlocked ();
	}

	public void saveState(){
		Debug.Log ("Saving game state");
		if (GameObject.Find ("Player") != null)
			player_pos = GameObject.Find ("Player").transform.position;
		Debug.Log ("Blanket game unlocked before saving: " + blanketGame.isUnlocked());
		string gameString = JsonUtility.ToJson (blanketGame) + "\n" + JsonUtility.ToJson (jobHuntGame) + "\n" + JsonUtility.ToJson (foodGame) + "\n" + JsonUtility.ToJson (player_pos);
		System.IO.File.WriteAllText ("gameState.txt", gameString);
	}

	public void loadState(){
		Debug.Log ("File lists: " + System.IO.Directory.GetCurrentDirectory());
		if (System.IO.File.Exists("gameState.txt")) {
			string[] jsons = System.IO.File.ReadAllLines ("gameState.txt");
			blanketGame = JsonUtility.FromJson<MiniGame> (jsons[0]);
			Debug.Log ("Successfully loaded blanket game state");
			Debug.Log (GameObject.Find ("GameState").GetComponent<GameState> ().blanketGame.gameName + "Blanket game unlocked: " + GameObject.Find ("GameState").GetComponent<GameState> ().blanketGame.isUnlocked ());
			jobHuntGame = JsonUtility.FromJson<MiniGame> (jsons[1]);
			foodGame = JsonUtility.FromJson<MiniGame> (jsons[2]);
			player_pos = JsonUtility.FromJson<Vector3> (jsons[3]);
		} else {
			blanketGame = new MiniGame(BlanketGame);
			jobHuntGame = new MiniGame (JobHuntGame);
			foodGame = new MiniGame (FoodGame);
			player_pos = Vector3.zero;
		}


		if (GameObject.Find ("Player") != null)
			GameObject.Find ("Player").transform.position = player_pos;
	}
}
