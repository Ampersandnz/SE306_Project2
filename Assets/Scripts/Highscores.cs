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
	}
	
	void OnGUI () {
		GUI.skin = skin;

		// Title
		GUI.Label (new Rect (Screen.width / 2 - 150, 50, 300, 90), "High Scores", textStyleTitle);

		// List high scores
	
		// Button to go back to endless runner mode menu.
		if(GUI.Button(new Rect(Screen.width/2-150, 310 , 300,90), "Back", textStyleButton)) {
			Application.LoadLevel("EndlessRunnerMode");
			soundPlayer.PlaySoundEffect ("menu");
		}

		// Button to toggle music
		if(GUI.Button(new Rect(Screen.width-250,20,100,90), musicSymbol, textStyleButton)) {
			soundPlayer.PlaySoundEffect ("menu");
			soundPlayer.ToggleMusic("menu");
		}

		// Button to toggle sound effects
		if(GUI.Button(new Rect(Screen.width-140,20,110,90), "sfx", textStyleButton)) {
			soundPlayer.PlaySoundEffect ("menu");
			soundPlayer.ToggleSound();
		}
	}
}