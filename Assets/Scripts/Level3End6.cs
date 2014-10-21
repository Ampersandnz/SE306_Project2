using UnityEngine;
using System.Collections;

public class Level3End6 : MonoBehaviour {

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
		if(GUI.Button(new Rect(Screen.width/30*24, Screen.height/20*11 + Screen.height/10*3, Screen.width/5, Screen.height/20*3), "Main Menu", textStyleButton)) {
			Application.LoadLevel("Start");
		}
	}
}
