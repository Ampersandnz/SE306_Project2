using UnityEngine;
using System.Collections;

// Class to display the menu for endless mode.
public class EndlessMode : MonoBehaviour {
	private SoundPlayer soundPlayer;
	public GUIStyle textStyleTitle;
	public GUIStyle textStyleButton;
	public GUISkin skin;
	private bool hasMusic = SoundPlayer.music;
	private bool hasSound = SoundPlayer.sound;
	public Texture2D noMusic, music, noSound, sound;

	// Loading the sound player.
	void Start(){
		soundPlayer = FindObjectOfType(typeof(SoundPlayer)) as SoundPlayer;
		DontDestroyOnLoad (soundPlayer);

		textStyleTitle.fontSize = Screen.height / 50 * 4;
		textStyleButton.fontSize = Screen.height / 50 * 3;
	}


	// Displaying everything.
	void OnGUI () {
		GUI.skin = skin;

		// Title
		GUI.Label (new Rect (Screen.width / 2 - Screen.width/6, Screen.height/20, Screen.width/3, Screen.height/20*3), "Endless runner mode", textStyleTitle);

		// Button to play the endless mode
		if(GUI.Button(new Rect(Screen.width/2-Screen.width/6, Screen.height/20*3 , Screen.width/3, Screen.height/20*3), "Play", textStyleButton)) {
			Application.LoadLevel("StartOfEndless");
			soundPlayer.PlaySoundEffect ("menu");
		}

		// Button to see the high scores.
		if(GUI.Button(new Rect(Screen.width/2-Screen.width/6, Screen.height/20*3 + Screen.height/10, Screen.width/3, Screen.height/20*3), "High scores", textStyleButton)) {
			Application.LoadLevel("Highscores");
			soundPlayer.PlaySoundEffect ("menu");
		}

		// Button to go back to main menu
		if((GUI.Button(new Rect(Screen.width/2-Screen.width/6, Screen.height/20*3 + Screen.height/5 , Screen.width/3, Screen.height/20*3), "Back", textStyleButton)) || (Input.GetKeyDown(KeyCode.Escape))) {
			Application.LoadLevel("MainMenu");
			soundPlayer.PlaySoundEffect ("menu");
		}

		// Button to toggle music
		if (hasMusic == true) {
			if (GUI.Button (new Rect (Screen.width - Screen.width / 27 * 5, Screen.height / 20 , Screen.width / 25, Screen.height / 20 * 3), music, textStyleButton)) {
				soundPlayer.PlaySoundEffect ("menu");
				hasMusic = soundPlayer.ToggleMusic ("menu");
			}
		} else {
			if (GUI.Button (new Rect (Screen.width - Screen.width / 27 * 5, Screen.height / 20 , Screen.width / 25, Screen.height / 20 * 3), noMusic, textStyleButton)) {
				soundPlayer.PlaySoundEffect ("menu");
				hasMusic = soundPlayer.ToggleMusic ("menu");
			}
		}
		
		
		if (hasSound == true) {
			if(GUI.Button(new Rect(Screen.width-Screen.width/60*7, Screen.height/20, Screen.width / 25, Screen.height / 20 * 3), sound, textStyleButton)){
				soundPlayer.PlaySoundEffect ("menu");
				hasSound = soundPlayer.ToggleSound();
			}
		} else {
			if(GUI.Button(new Rect(Screen.width-Screen.width/60*7, Screen.height/20, Screen.width / 25, Screen.height / 20 * 3), noSound, textStyleButton)) {
				soundPlayer.PlaySoundEffect ("menu");
				hasSound = soundPlayer.ToggleSound();
			}
		}
	}
}
