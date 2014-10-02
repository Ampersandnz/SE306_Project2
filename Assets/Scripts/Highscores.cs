using UnityEngine;
using System.Collections;

public class Highscores : MonoBehaviour {
	
	void OnGUI () {
		GUI.Box (new Rect (10, 10, 100, 60), "Menu");

		// List high scores

		if (GUI.Button (new Rect (20, 40, 80, 20), "Back")) {
			Application.LoadLevel ("EndlessRunnerMode");
		}
	}
}
