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
	public string musicSymbol;
	
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
			if(cheatCode=="jellybeans"){
				PlayerPrefs.SetInt("SwiperStarsL1",3);
				PlayerPrefs.SetInt("SwiperStarsL2",3);
				PlayerPrefs.SetInt("SwiperStarsL3",3);

				Application.LoadLevel("MainMenu");
				soundPlayer.PlaySoundEffect ("menu");
			}
			if(cheatCode=="android"){
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
		if(GUI.Button(new Rect(Screen.width-Screen.width/24*5,Screen.height/30, Screen.width/12 , Screen.height/20*3), musicSymbol, textStyleButton)) {
			soundPlayer.PlaySoundEffect ("menu");
			soundPlayer.ToggleMusic("menu");
		}
		
		// Button to toggle sound effects
		if(GUI.Button(new Rect(Screen.width-Screen.width/60*7, Screen.height/30, Screen.width/120*11, Screen.height/20*3), "sfx", textStyleButton)) {
			soundPlayer.PlaySoundEffect ("menu");
			soundPlayer.ToggleSound();
		}
		
		
		
		
		//Get the User to enter their name
		//GUI.Label (new Rect (Screen.width / 2 - Screen.width/4 - Screen.width/50, Screen.height/3, Screen.width/3, Screen.height/20*3), "Name:", textStyleTitle);
		cheatCode = GUI.TextField(new Rect (Screen.width / 2 - Screen.width/4, Screen.height/3, Screen.width/3, Screen.height/20*3), cheatCode, 12, textStyleInput);
		
		//GUI.Label (new Rect (Screen.width / 2 - Screen.width/4 - Screen.width/50, Screen.height/20*6 + Screen.height/5 , Screen.width/3, Screen.height/20*3), "Score:", textStyleTitle);
		//GUI.Label (new Rect (Screen.width / 2 + Screen.width/50, Screen.height/20*6 + Screen.height/5 , Screen.width/3, Screen.height/20*3), score , textStyleTitle);
		
	}
	
}