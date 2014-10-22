using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Class to display the high scores.
public class Cheat : MonoBehaviour {
	private SoundPlayer soundPlayer;
	public GUIStyle textStyleTitle;
	public GUIStyle textStyleButton;
	public GUIStyle textStyleInput;
	public GUISkin skin;

	private bool hasMusic = SoundPlayer.music;
	private bool hasSound = SoundPlayer.sound;
	public Texture2D noMusic, music, noSound, sound;

	
	string cheatCode="";

	// Initialise the sound player and highscores
	void Start(){
		soundPlayer = FindObjectOfType(typeof(SoundPlayer)) as SoundPlayer;
		DontDestroyOnLoad (soundPlayer);
		
		textStyleTitle.fontSize = Screen.height / 50 * 4;
		textStyleInput.fontSize = Screen.height / 50 * 4;
		textStyleButton.fontSize = Screen.height / 50 * 3;
		
		GUI.SetNextControlName (cheatCode);
	}
	
	
	
	void OnGUI () {
		textStyleTitle.fontSize = Screen.height / 50 * 4;
		GUI.skin = skin;
		
		// Title
		GUI.Label (new Rect (Screen.width / 2 - Screen.width/6, Screen.height/20, Screen.width/3, Screen.height/20*3), "Cheat", textStyleTitle);
		
		
		// Button to go back to endless runner mode menu.
		if (GUI.Button(new Rect(Screen.width/2+Screen.width/50, Screen.height/60*43, Screen.width/4, Screen.height/20*3), "Continue", textStyleButton)) {
			if(cheatCode.ToLower()=="jellybeans"){
				PlayerPrefs.SetInt("SwiperStarsL1",3);
				PlayerPrefs.SetInt("SwiperStarsL2",3);
				PlayerPrefs.SetInt("SwiperStarsL3",3);

				Application.LoadLevel("MainMenu");
				soundPlayer.PlaySoundEffect ("menu");
			}
			if(cheatCode.ToLower()=="android"){
				PlayerPrefs.DeleteAll();
				Application.LoadLevel("MainMenu");
				soundPlayer.PlaySoundEffect ("menu");

			}
		}

		// Back button
		if((GUI.Button(new Rect(Screen.width/2-Screen.width/4, Screen.height/60*43, Screen.width/4, Screen.height/20*3), "Back", textStyleButton)) || (Input.GetKeyDown(KeyCode.Escape))) {
			Application.LoadLevel("MainMenu");
			soundPlayer.PlaySoundEffect ("menu");
		}
		//Cheat button
		if(GUI.Button(new Rect(Screen.width/2+Screen.width/50, Screen.height/60*43, Screen.width/4, Screen.height/20*3), "Cheat", textStyleButton)) {
			Application.LoadLevel("Cheat");
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
		
		
		
		//Get the User to enter their name
		//GUI.Label (new Rect (Screen.width / 2 - Screen.width/4 - Screen.width/50, Screen.height/3, Screen.width/3, Screen.height/20*3), "Name:", textStyleTitle);
		cheatCode = GUI.TextField(new Rect (Screen.width / 2 - Screen.width/4, Screen.height/3, Screen.width/3, Screen.height/20*3), cheatCode, 12, textStyleInput);
		
		//GUI.Label (new Rect (Screen.width / 2 - Screen.width/4 - Screen.width/50, Screen.height/20*6 + Screen.height/5 , Screen.width/3, Screen.height/20*3), "Score:", textStyleTitle);
		//GUI.Label (new Rect (Screen.width / 2 + Screen.width/50, Screen.height/20*6 + Screen.height/5 , Screen.width/3, Screen.height/20*3), score , textStyleTitle);
		
	}
	
}