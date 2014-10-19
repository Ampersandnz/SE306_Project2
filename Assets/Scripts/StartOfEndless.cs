using UnityEngine;
using System.Collections;

public class StartOfEndless : MonoBehaviour {

	public GUIStyle textStyleButton;
	public GUISkin skin;
	public GUIStyle textStyleTitle;
	
	// Use this for initialization
	void Start () {
		textStyleButton.fontSize = Screen.height / 50 * 3;
		textStyleTitle.fontSize = Screen.height / 50 * 4;
		
	}
	
	// Displaying everything
	void OnGUI () {
		GUI.skin = skin;
		
		// Button to go back to main menu
		if(GUI.Button(new Rect(Screen.width/30*25, Screen.height/20*11 + Screen.height/10*3, Screen.width/6, Screen.height/20*3), "Next", textStyleButton)) {
			Application.LoadLevel("Level3End2");
		}
	}
}
