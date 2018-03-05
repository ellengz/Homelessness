using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GenderComparerScript : MonoBehaviour {

	public string Gender;
	public int TestResult;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		Gender = GameObject.Find("Player").GetComponent<PlayerAccountScript>().playerInfo.sex;
		int dropdown = (int) GameObject.Find("Dropdown").GetComponent<Dropdown>().value;
		int sex = (Gender.Equals("girl"))? 0:1;

		TestResult = (sex == dropdown) ? 1:0;
	}
}
