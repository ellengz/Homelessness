using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class JobHuntFind {

	[Test]
	public void TestSimplePasses() {
		// Use the Assert class to test conditions.
		bool throwing = false;
		foreach (var obj in GameObject.FindGameObjectsWithTag("Newspaper")) {
			if (obj.transform.hasChanged) {
				Debug.Log ("The transform has changed!");
				throwing = true;
			} else {
				throwing = false;			
			}
		}
		Assert.True (throwing);
	}

	// A UnityTest behaves like a coroutine in PlayMode
	// and allows you to yield null to skip a frame in EditMode
	[UnityTest]
	public IEnumerator TestWithEnumeratorPasses() {
		// Use the Assert class to test conditions.
		// yield to skip a frame
		yield return null;
	}
}
