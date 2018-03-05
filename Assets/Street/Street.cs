using UnityEngine;
using System.Collections;

public class Street : MonoBehaviour {
	public int population;
	public float yOffset;

	public float minX, maxX, minY, maxY;

	public float GetDepth(float y) {
		return (y - minY) / (maxY - minY);
	}

	public Vector3 RandomStreetLocation() {
		float x = (Random.value - 0.5f) * GetComponent<BoxCollider> ().size.x;
		float z = (Random.value - 0.5f) * GetComponent<BoxCollider> ().size.y;
		return new Vector3 (x, 0, z);
	}

	void Start () {
		DialogueBox.isOpen = false;
		GameObject npcPrefab = Resources.Load ("NPC") as GameObject;
		string npcSex;
		for (int i = 0; i < population; i++) {
			// create NPCs at random locations
			GameObject npcHair = new GameObject ();
			npcHair.AddComponent<SpriteRenderer> ();
			GameObject npcBody = new GameObject ();
			npcBody.AddComponent<SpriteRenderer> ();
			if (Random.Range (0, 2) == 0) {
				npcSex = "girl";
			} else {
				npcSex = "boy";
			}
			npcHair.GetComponentInChildren<SpriteRenderer> ().sprite = Resources.Load<Sprite> (npcSex + "_head" + Random.Range (1, 4));
			npcBody.GetComponentInChildren<SpriteRenderer> ().sprite = Resources.Load<Sprite> (npcSex + "_body" + Random.Range (1, 4));
			GameObject npc = (GameObject)Instantiate(npcPrefab, RandomStreetLocation(), Quaternion.identity, this.transform);
			npcBody.transform.parent = npc.transform;
			npcHair.transform.parent = npc.transform;
			npcHair.transform.localPosition = new Vector3(0, 0.2f, -0.0001f);
			npcBody.transform.localPosition = new Vector3 (0.3f, 0, -0.0002f);
			npc.transform.localScale = new Vector3 (0.15f, 0.15f, 0.15f);
			npc.SetActive (true);
//			npcHair.GetComponentInChildren<SpriteRenderer> ().sortingOrder = 0;
//			npcBody.GetComponentInChildren<SpriteRenderer> ().sortingOrder = 0;
//			npc.GetComponentInChildren<SpriteRenderer> ().sortingOrder = 0;

			//npcHair.transform.localScale = new Vector3 (0.1f,0.1f,0.1f);
			//npcBody.transform.localScale = new Vector3 (0.1f,0.1f,0.1f);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown () {
		if (!GameObject.FindGameObjectWithTag("DialogueBox")) {
			// walk to position
			Walk playerWalk = GameObject.FindGameObjectWithTag("Player").GetComponent<Walk>();
			playerWalk.target = UnityEngine.Camera.main.ScreenToWorldPoint (Input.mousePosition);

			Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit))
			{
				playerWalk.target = hit.point;
			}
		}
	}
}
