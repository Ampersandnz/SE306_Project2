using UnityEngine;
using System.Collections;

// Class for the in-game pause menu
public class PauseMenu : MonoBehaviour {

	SoundPlayer soundPlayer;
	public GUIStyle textStyleTitle;
	public GUIStyle textStyleButton;
	public GUISkin skin;
	public bool isPaused;
	private bool confirmRestart;
	private bool confirmQuit;

	// Initialising sound player
	void Start () {
		isPaused = false;
		confirmRestart = false;
		confirmQuit = false;

		soundPlayer = FindObjectOfType(typeof(SoundPlayer)) as SoundPlayer;
		soundPlayer.PlayStoryMusic ();
		DontDestroyOnLoad (soundPlayer);
	}

	// Displaying everything
	void OnGUI(){
		// If the game is actually paused, then:
		if (isPaused == true) {
			if(confirmRestart==false && confirmQuit==false){
				Time.timeScale = 0.0f; // Stop time

				// Display title
				GUI.Label (new Rect (Screen.width / 2 - 150, 50, 300, 90), "Paused", textStyleTitle);

				// Button to resume game
				if (GUI.Button (new Rect (Screen.width / 2 - 150, 90, 300, 90), "Resume", textStyleButton)) {
					soundPlayer.PlaySoundEffect ("menu");
					// Ask for confirmation

					isPaused = false;
					Time.timeScale = 1.0f;
				}

				// Button to restart level
				if (GUI.Button (new Rect (Screen.width / 2 - 150, 150, 300, 90), "Restart", textStyleButton)) {
					soundPlayer.PlaySoundEffect ("menu");
					confirmRestart = true;
				}

				// Button to quit game
				if (GUI.Button (new Rect (Screen.width / 2 - 150, 210, 300, 90), "Quit", textStyleButton)) {
					soundPlayer.PlaySoundEffect ("menu");
					confirmQuit = true;
				}

				// Button to toggle music
				if (GUI.Button (new Rect (Screen.width / 2 - 150, 270, 300, 90), "Toggle music", textStyleButton)) {
					soundPlayer.PlaySoundEffect ("menu");
					soundPlayer.ToggleMusic ("story");
				}

				// Button to toggle sounds
				if (GUI.Button (new Rect (Screen.width / 2 - 150, 330, 300, 90), "Toggle sfx", textStyleButton)) {
					soundPlayer.PlaySoundEffect ("menu");
					soundPlayer.ToggleSound ();
				}

			}else if(confirmRestart==true){ // Asking user for confirmation that they want to restart the level

				GUI.Label (new Rect (Screen.width / 2 - 150, 100, 300, 90), "Are you sure you want to restart?", textStyleTitle);

				// Button to restart level
				if (GUI.Button (new Rect (Screen.width / 2 - 150, 150, 300, 90), "Yes", textStyleButton)) {
					soundPlayer.PlaySoundEffect ("menu");
					isPaused = false;
					confirmRestart = false;
					Time.timeScale = 1.0f;
					Application.LoadLevel ("StoryLevel1");
				}
				
				// Button to go back to pause menu
				if (GUI.Button (new Rect (Screen.width / 2 - 150, 210, 300, 90), "No", textStyleButton)) {
					soundPlayer.PlaySoundEffect ("menu");
					confirmRestart = false;
				}

			}else if(confirmQuit==true){ // Asking user for confirmation that they want to quit the game

				GUI.Label (new Rect (Screen.width / 2 - 150, 100, 300, 90), "Are you sure you want to quit the game?", textStyleTitle);
				
				// Button to restart level
				if (GUI.Button (new Rect (Screen.width / 2 - 150, 150, 300, 90), "Yes", textStyleButton)) {
					soundPlayer.PlaySoundEffect ("menu");
					isPaused = false;
					confirmQuit = false;
					Time.timeScale = 1.0f;
					Application.LoadLevel ("Start");
				}
				
				// Button to go back to pause menu
				if (GUI.Button (new Rect (Screen.width / 2 - 150, 210, 300, 90), "No", textStyleButton)) {
					soundPlayer.PlaySoundEffect ("menu");
					confirmQuit = false;
				}
			}
		}
	}
}
