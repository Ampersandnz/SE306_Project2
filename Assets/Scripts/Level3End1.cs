﻿using UnityEngine;
using System.Collections;

public class Level3End1 : MonoBehaviour {

	public GUIStyle textStyleButton;
	public GUISkin skin;
	
	// Use this for initialization
	void Start () {
		textStyleButton.fontSize = Screen.height / 50 * 3;
		
	}
	
	// Displaying everything
	void OnGUI () {
		GUI.skin = skin;
		
		// Button to go back to main menu
		if(GUI.Button(new Rect(Screen.width/8*7, Screen.height/20*12 + Screen.height/10*3, Screen.width/3, Screen.height/20*3), "Next", textStyleButton)) {
			Application.LoadLevel("Level3End2");
		}
	}
}
