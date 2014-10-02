using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	
	void OnGUI () {
		// Make a background box
		GUI.Box(new Rect(10,10,100,90), "Menu");
		
		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect(20,40,80,20), "Story mode")) {
			Application.LoadLevel("StoryLevelSelect");
		}
		
		// Make the second button.
		if(GUI.Button(new Rect(20,70,80,20), "Options")) {
			Application.LoadLevel(2);
		}
	}
}