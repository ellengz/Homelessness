using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.UI;

public class Score {

	[Test]
	public void ScoreSimplePasses() {
		// Use the Assert class to test conditions.
		Assert.AreEqual (GameObject.FindGameObjectWithTag("Score").GetComponent<Text>().text, "0");
	}

	// A UnityTest behaves like a coroutine in PlayMode
	// and allows you to yield null to skip a frame in EditMode
	[UnityTest]
	public IEnumerator ScoreWithEnumeratorPasses() {
		// Use the Assert class to test conditions.
		// yield to skip a frame
		yield return null;
	}

	public IEnumerator ExecuteAfterTime()
	{
		yield return new WaitForSeconds(2);
		Assert.AreEqual (GameObject.FindGameObjectWithTag("Score").GetComponent<Text>().text, "1");
		// Code to execute after the delay
	}
}
