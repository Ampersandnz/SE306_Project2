using UnityEngine;
using System.Collections;

// Class to display the high scores.
public class Highscores : MonoBehaviour {
	private SoundPlayer soundPlayer;
	public GUIStyle textStyleTitle;
	public GUIStyle textStyleButton;
	public GUISkin skin;
	public string musicSymbol;

	// Initialise the sound player.
	void Start(){
		soundPlayer = FindObjectOfType(typeof(SoundPlayer)) as SoundPlayer;
		DontDestroyOnLoad (soundPlayer);
		
		textStyleTitle.fontSize = Screen.height / 50 * 4;
		textStyleButton.fontSize = Screen.height / 50 * 3;
	}
	
	void OnGUI () {
		GUI.skin = skin;

		// Title
		GUI.Label (new Rect (Screen.width / 2 - Screen.width/6, Screen.height/20, Screen.width/3, Screen.height/20*3), "High Scores", textStyleTitle);

		GUI.Label (new Rect (Screen.width / 2 - Screen.width/4, Screen.height/20*3, Screen.width/2, Screen.height/20*3), "(this feature not implemented yet)", textStyleTitle);

		// List high scores
	
		// Button to go back to endless runner mode menu.
		if((GUI.Button(new Rect(Screen.width/2-Screen.width/6, Screen.height/20*3 + Screen.height/5 , Screen.width/3, Screen.height/20*3), "Back", textStyleButton)) || (Input.GetKeyDown(KeyCode.Escape))) {
			Application.LoadLevel("EndlessRunnerMode");
			soundPlayer.PlaySoundEffect ("menu");
		}

		// Disclaimer.

		// Button to toggle music
		if(GUI.Button(new Rect(Screen.width-Screen.width/24*5,Screen.height/30, Screen.width/12 , Screen.height/20*3), musicSymbol, textStyleButton)) {
			soundPlayer.PlaySoundEffect ("menu");
			soundPlayer.ToggleMusic("menu");
		}

		// Button to toggle sound effects
		if(GUI.Button(new Rect(Screen.width-Screen.width/60*7, Screen.height/30, Screen.width/120*11, Screen.height/20*3), "sfx", textStyleButton)) {
			soundPlayer.PlaySoundEffect ("menu");
			soundPlayer.ToggleSound();
		}
	}
}