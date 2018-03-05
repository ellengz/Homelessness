using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	void Start () {
		PlayerAccountScript.PlayerInfo playerInfo = loadPlayerInfo ();
		if (playerInfo != null) {
			GameObject.Find ("Hair").GetComponent<SpriteRenderer> ().sprite =
				Resources.Load<Sprite> (playerInfo.sex + "_head" + playerInfo.hair);
			GameObject.Find ("Body").GetComponent<SpriteRenderer> ().sprite =
				Resources.Load<Sprite> (playerInfo.sex + "_body" + playerInfo.body);
		} else {
			GameObject.Find ("Hair").GetComponent<SpriteRenderer> ().sprite =
				Resources.Load<Sprite> ("girl_head1");
			GameObject.Find ("Body").GetComponent<SpriteRenderer> ().sprite =
				Resources.Load<Sprite> ("girl_body1");
			GameObject.Find ("Face").GetComponent<SpriteRenderer> ().sprite =
				Resources.Load<Sprite> ("face");
		}
	}

	void Update () {
		
	}

	public PlayerAccountScript.PlayerInfo loadPlayerInfo(){
		if (System.IO.File.Exists("playerInfo.txt")) {
			string json = System.IO.File.ReadAllText ("playerInfo.txt");
			return JsonUtility.FromJson<PlayerAccountScript.PlayerInfo> (json);
		} else {
			return null;
		}
	}
}
