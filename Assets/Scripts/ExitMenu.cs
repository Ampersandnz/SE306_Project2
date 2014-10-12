using UnityEngine;
using System.Collections;

//Class to display exit dialog
public class ExitMenu : MonoBehaviour {

	SoundPlayer soundPlayer;
	public GUIStyle textStyleTitle;
	public GUIStyle textStyleButton;
	public GUISkin skin;
	public bool backPressed;
	// Use this for initialization
	void Start () {
		backPressed = false;
		soundPlayer = FindObjectOfType(typeof(SoundPlayer)) as SoundPlayer;
		DontDestroyOnLoad (soundPlayer);
		
		textStyleButton.fontSize = Screen.height / 50 * 3;
	}
	

	void OnGUI() {
		if (backPressed) {
			GUI.Box(new Rect (Screen.width / 2 - Screen.width/6, Screen.height/6, Screen.width/3, Screen.height/2), "Are you sure you want to quit?");
			if (GUI.Button (new Rect (Screen.width / 2 - Screen.width/8, Screen.height/4, Screen.width/4, Screen.height/20*3), "Yes", textStyleButton)) {
				Application.Quit ();
			}
			if (GUI.Button (new Rect (Screen.width / 2 - Screen.width/8, Screen.height/4+Screen.height/10, Screen.width/4, Screen.height/20*3), "No", textStyleButton)) {
				Application.LoadLevel("MainMenu");
				soundPlayer.PlaySoundEffect ("menu");
				backPressed = false;
			}
		}
	}
}
