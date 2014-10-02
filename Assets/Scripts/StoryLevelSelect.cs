using UnityEngine;
using System.Collections;

public class StoryLevelSelect : MonoBehaviour {
	void OnGUI () {
		GUI.Box(new Rect(10,10,100,150), "Story mode");

		if(GUI.Button(new Rect(20,40,80,20), "Level 1")) {
			Application.LoadLevel("StoryLevel1");
		}

		if(GUI.Button(new Rect(20,70,80,20), "Level 2")) {
			Application.LoadLevel("StoryLevel2");
		}

		if(GUI.Button(new Rect(20,100,80,20), "Level 3")) {
			Application.LoadLevel("StoryLevel3");
		}

		if(GUI.Button(new Rect(20,130,80,20), "Back")) {
			Application.LoadLevel("MainMenu");
		}
	}
}
