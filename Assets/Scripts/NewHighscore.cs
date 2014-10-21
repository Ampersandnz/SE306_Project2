using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Class to display the high scores.
public class NewHighscore : MonoBehaviour {
	private SoundPlayer soundPlayer;
	public GUIStyle textStyleTitle;
	public GUIStyle textStyleButton;
	public GUISkin skin;
	public string musicSymbol;
	
	string name="";
	string score="";
	private PlayerEndless player; // Initialising reference to player
	
	// Initialise the sound player and highscores
	void Start(){
		player = FindObjectOfType(typeof(PlayerEndless)) as PlayerEndless;
		soundPlayer = FindObjectOfType(typeof(SoundPlayer)) as SoundPlayer;
		DontDestroyOnLoad (soundPlayer);
		
		textStyleTitle.fontSize = Screen.height / 50 * 4;
		textStyleButton.fontSize = Screen.height / 50 * 3;
		
		//Store the best highscore as the expected new highscore name
		if (PlayerPrefs.HasKey ("SwiperHighscore1name")) {
			name = PlayerPrefs.GetString ("SwiperHighscore1name");
		} else {
			name = "Swiper";
		}
		score = PlayerPrefs.GetInt ("SwiperNewHighscore").ToString();
		GUI.SetNextControlName (name);
	}
	
	
	
	void OnGUI () {
		textStyleTitle.fontSize = Screen.height / 50 * 4;
		GUI.skin = skin;
		
		// Title
		GUI.Label (new Rect (Screen.width / 2 - Screen.width/6, Screen.height/20, Screen.width/3, Screen.height/20*3), "Please Enter Your Name", textStyleTitle);
		
		
		// Button to go back to endless runner mode menu.
		if((GUI.Button(new Rect(Screen.width/2-Screen.width/6, Screen.height/20*13 + Screen.height/5 , Screen.width/3, Screen.height/20*3), "Continue", textStyleButton))) {
			if(name!=""){
				HighScoreManager._instance.SaveHighScore(name,PlayerPrefs.GetInt("SwiperNewHighscore"));
				Application.LoadLevel("Highscores");
				soundPlayer.PlaySoundEffect ("menu");
			}
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
		GUI.Label (new Rect (Screen.width / 2 - Screen.width/4 - Screen.width/50, Screen.height/3, Screen.width/3, Screen.height/20*3), "Name:", textStyleButton);
		name = GUI.TextField(new Rect (Screen.width / 2 + Screen.width/50, Screen.height/3, Screen.width/3, Screen.height/20*3), name, 25, textStyleButton);
		
		GUI.Label (new Rect (Screen.width / 2 - Screen.width/4 - Screen.width/50, Screen.height/20*6 + Screen.height/5 , Screen.width/3, Screen.height/20*3), "Score:", textStyleButton);
		GUI.Label (new Rect (Screen.width / 2 + Screen.width/50, Screen.height/20*6 + Screen.height/5 , Screen.width/3, Screen.height/20*3), score , textStyleButton);
		
	}
}