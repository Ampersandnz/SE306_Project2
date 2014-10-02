using UnityEngine;
using System.Collections;

public class EndlessMode : MonoBehaviour {
	void OnGUI () {
		GUI.Box(new Rect(10,10,100,120), "Endless mode");

		if(GUI.Button(new Rect(20,40,80,20), "Play game")) {
			Application.LoadLevel("EndlessModePlay");
		}

		if(GUI.Button(new Rect(20,70,80,20), "Highscores")) {
			Application.LoadLevel("Highscores");
		}

		if(GUI.Button(new Rect(20,100,80,20), "Back")) {
			Application.LoadLevel("MainMenu");
		}
	}
}
