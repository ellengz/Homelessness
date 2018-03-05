using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AccountComparerScript : MonoBehaviour {

	public class TestSet{
		public string name;
		public int player, slider;
	}

	public int TestResult;

	public TestSet hair = new TestSet ();
	public TestSet body = new TestSet ();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
		hair.player = GameObject.Find("Player").GetComponent<PlayerAccountScript>().playerInfo.hair;
		body.player = GameObject.Find("Player").GetComponent<PlayerAccountScript>().playerInfo.body;

		hair.slider = (int) GameObject.Find("HairSlider").GetComponent<Slider>().value;
		body.slider = (int) GameObject.Find("ClothesSlider").GetComponent<Slider>().value;

		TestResult = (hair.player == hair.slider && body.player == body.slider) ? 1 : 0;

	}
}
