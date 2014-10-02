using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	
	void OnGUI () {
		GUI.Box(new Rect(10,10,120,120), "Menu");

		if(GUI.Button(new Rect(20,40,100,20), "Story mode")) {
			Application.LoadLevel("StoryLevelSelect");
		}

		if(GUI.Button(new Rect(20,70,100,20), "Endless mode")) {
			Application.LoadLevel("EndlessRunnerMode");
		}

		if(GUI.Button(new Rect(20,100,100,20), "Options")) {
			Application.LoadLevel("Options");
		}
	}
}