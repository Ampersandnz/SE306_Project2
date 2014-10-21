using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Adapted from http://answers.unity3d.com/questions/20773/how-do-i-make-a-highscores-board.html

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

		if (PlayerPrefs.HasKey("SwiperHighscore1name")){
			name = PlayerPrefs.GetString("SwiperHighscore1name");
		}
		//Currently do not need
		//EventManager._instance._buttonClick += ButtonClicked;

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
		


		//Keep to make sure the size of the textfield for the user to enter their name stays the same
		GUILayout.Space(60);
		GUILayout.BeginHorizontal();
		GUILayout.Label("",textStyleTitle,GUILayout.Width(Screen.width/2));
		GUILayout.Label("",textStyleTitle,GUILayout.Width(Screen.width/2));
		GUILayout.EndHorizontal();
		GUILayout.Space(25);

		//Have a textfield for the user to enter their name
		name =  GUILayout.TextField(name);
	}
}