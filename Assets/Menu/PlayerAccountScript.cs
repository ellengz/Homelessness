using UnityEngine;
using System.Collections;
using System;

public class PlayerAccountScript : MonoBehaviour {
	
	[Serializable]
	public class PlayerInfo {
		public string name = "Marry";
		public string sex = "girl";
		public int hair, body;
	}

	public PlayerInfo playerInfo = new PlayerInfo();
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (transform.gameObject);
		playerInfo.sex = "girl";
		playerInfo.hair = 1;
		playerInfo.body = 1;
		ReloadSprite ();
	}

	public void ReloadSprite() {
		GameObject.Find ("Hair").GetComponent<SpriteRenderer> ().sprite =
			Resources.Load<Sprite> (playerInfo.sex + "_head" + playerInfo.hair);
		GameObject.Find ("Body").GetComponent<SpriteRenderer> ().sprite =
			Resources.Load<Sprite> (playerInfo.sex + "_body" + playerInfo.body);
	}

	// Update is called once per frame
	void Update () {
	}

	public void SavePlayerInfo(){
		string json = JsonUtility.ToJson (playerInfo);
		System.IO.File.WriteAllText ("playerInfo.txt", json);
	}
}
