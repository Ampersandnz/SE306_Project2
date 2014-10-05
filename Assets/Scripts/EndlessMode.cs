using UnityEngine;
using System.Collections;

// Class to display the menu for endless mode.
public class EndlessMode : MonoBehaviour {
	private SoundPlayer soundPlayer;
	public GUIStyle textStyleTitle;
	public GUIStyle textStyleButton;
	public GUISkin skin;
	public string musicSymbol;

	// Loading the sound player.
	void Start(){
		soundPlayer = FindObjectOfType(typeof(SoundPlayer)) as SoundPlayer;
		DontDestroyOnLoad (soundPlayer);
	}


	// Displaying everything.
	void OnGUI () {
		GUI.skin = skin;

		// Title
		GUI.Label (new Rect (Screen.width / 2 - 150, 50, 300, 90), "Endless runner mode", textStyleTitle);

		// Button to play the endless mode
		if(GUI.Button(new Rect(Screen.width/2-150, 90 , 300,90), "Play", textStyleButton)) {
			Application.LoadLevel("EndlessModePlay");
			soundPlayer.PlaySoundEffect ("menu");
		}

		// Button to see the high scores.
		if(GUI.Button(new Rect(Screen.width/2-150, 150 , 300,90), "High scores", textStyleButton)) {
			Application.LoadLevel("Highscores");
			soundPlayer.PlaySoundEffect ("menu");
		}
		
		if(GUI.Button(new Rect(Screen.width/2-150, 210 , 300,90), "Back", textStyleButton)) {
			Application.LoadLevel("MainMenu");
			soundPlayer.PlaySoundEffect ("menu");
		}

		// Button to toggle music
		if(GUI.Button(new Rect(Screen.width-250,20,100,90), musicSymbol, textStyleButton)) {
			soundPlayer.PlaySoundEffect ("menu");
			soundPlayer.ToggleMusic("menu");
		}

		// Button to toggle sound effects.
		if(GUI.Button(new Rect(Screen.width-140,20,110,90), "sfx", textStyleButton)) {
			soundPlayer.PlaySoundEffect ("menu");
			soundPlayer.ToggleSound();
		}
	}
}
