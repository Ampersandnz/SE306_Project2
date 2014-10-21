using UnityEngine;
using System.Collections;

// Class for the in-game pause menu
public class PauseMenuEndless : MonoBehaviour {

	SoundPlayer soundPlayer;
	public GUIStyle textStyleTitle;
	public GUIStyle textStyleButton;
	public GUISkin skin;
	public bool isPaused;
	private bool confirmRestart;
	private bool confirmQuit;
	private bool hasMusic = SoundPlayer.music;
	private bool hasSound = SoundPlayer.sound;

	// Initialising sound player
	void Start () {
		isPaused = false;
		confirmRestart = false;
		confirmQuit = false;

		soundPlayer = FindObjectOfType(typeof(SoundPlayer)) as SoundPlayer;
		soundPlayer.PlayStoryMusic ();
		DontDestroyOnLoad (soundPlayer);
		
		textStyleTitle.fontSize = Screen.height / 50 * 4;
		textStyleButton.fontSize = Screen.height / 50 * 3;
	}

	// Displaying everything
	void OnGUI(){
		// If the game is actually paused, then:
		if (isPaused == true) {
			if(confirmRestart==false && confirmQuit==false){
				Time.timeScale = 0.0f; // Stop time

				// Display title
				GUI.Label (new Rect (Screen.width / 2 - Screen.width/6, Screen.height/6, Screen.width/3, Screen.height/20*3), "Paused", textStyleTitle);

				// Button to resume game
				if (GUI.Button (new Rect (Screen.width / 2 - Screen.width/8, Screen.height/4, Screen.width/4, Screen.height/20*3), "Resume", textStyleButton)) {
					soundPlayer.PlaySoundEffect ("menu");
					isPaused = false;
					Time.timeScale = 1.0f;
				}

				// Button to restart level
				if (GUI.Button (new Rect (Screen.width / 2 - Screen.width/8, Screen.height/4+Screen.height/10, Screen.width/4, Screen.height/20*3), "Restart", textStyleButton)) {
					soundPlayer.PlaySoundEffect ("menu");
					confirmRestart = true;
				}

				// Button to quit game
				if (GUI.Button (new Rect (Screen.width / 2 - Screen.width/8, Screen.height/4+Screen.height/10*2, Screen.width/4, Screen.height/20*3), "Quit", textStyleButton)) {
					soundPlayer.PlaySoundEffect ("menu");
					confirmQuit = true;
				}

				// Button to toggle music
				string musicVal = hasMusic ? "Music: Off": "Music: On";
				if (GUI.Button (new Rect (Screen.width / 2 - Screen.width/8, Screen.height/4+Screen.height/10*3, Screen.width/4, Screen.height/20*3), musicVal, textStyleButton)) {
					soundPlayer.PlaySoundEffect ("menu");
					hasMusic = soundPlayer.ToggleMusic ("story");
				}
				
				// Button to toggle sounds
				string soundVal = hasSound ? "Sound: Off": "Sound: On";
				if (GUI.Button (new Rect (Screen.width / 2 - Screen.width/8, Screen.height/4+Screen.height/10*4, Screen.width/4, Screen.height/20*3), soundVal, textStyleButton)) {
					soundPlayer.PlaySoundEffect ("menu");
					hasSound = soundPlayer.ToggleSound ();
				}
			}else if(confirmRestart==true){ // Asking user for confirmation that they want to restart the level

				GUI.Label (new Rect (Screen.width / 2 - Screen.width/6, Screen.height/5, Screen.width/3, Screen.height/20*3), "Are you sure you want to restart?", textStyleTitle);

				// Button to restart level
				if (GUI.Button (new Rect (Screen.width / 2 - Screen.width/8, Screen.height/4, Screen.width/4, Screen.height/20*3), "Yes", textStyleButton)) {
					soundPlayer.PlaySoundEffect ("menu");
					isPaused = false;
					confirmRestart = false;
					Time.timeScale = 1.0f;
					Application.LoadLevel ("EndlessModePlay");
				}
				
				// Button to go back to pause menu
				if (GUI.Button (new Rect (Screen.width / 2 - Screen.width/8, Screen.height/4+Screen.height/10, Screen.width/4, Screen.height/20*3), "No", textStyleButton)) {
					soundPlayer.PlaySoundEffect ("menu");
					confirmRestart = false;
				}

			}else if(confirmQuit==true){ // Asking user for confirmation that they want to quit the game

				GUI.Label (new Rect (Screen.width / 2 - Screen.width/6, Screen.height/5, Screen.width/3, Screen.height/20*3), "Are you sure you want to quit the game?", textStyleTitle);
				
				// Button to restart level
				if (GUI.Button (new Rect (Screen.width / 2 - Screen.width/8, Screen.height/4, Screen.width/4, Screen.height/20*3), "Yes", textStyleButton)) {
					soundPlayer.PlaySoundEffect ("menu");
					isPaused = false;
					confirmQuit = false;
					Time.timeScale = 1.0f;
					Application.LoadLevel ("Start");
				}
				
				// Button to go back to pause menu
				if (GUI.Button (new Rect (Screen.width / 2 - Screen.width/8, Screen.height/4+Screen.height/10, Screen.width/4, Screen.height/20*3), "No", textStyleButton)) {
					soundPlayer.PlaySoundEffect ("menu");
					confirmQuit = false;
				}
			}
		}
	}
}