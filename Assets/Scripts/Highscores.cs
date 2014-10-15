using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Adapted from http://answers.unity3d.com/questions/20773/how-do-i-make-a-highscores-board.html

// Class to display the high scores.
public class Highscores : MonoBehaviour {
	private SoundPlayer soundPlayer;
	public GUIStyle textStyleTitle;
	public GUIStyle textStyleButton;
	public GUISkin skin;
	public string musicSymbol;

	string name="";
	string score="";
	List<Scores> highscore;

	// Initialise the sound player and highscores
	void Start(){
		soundPlayer = FindObjectOfType(typeof(SoundPlayer)) as SoundPlayer;
		DontDestroyOnLoad (soundPlayer);
		
		textStyleTitle.fontSize = Screen.height / 50 * 4;
		textStyleButton.fontSize = Screen.height / 50 * 3;

		//Currently do not need
		//EventManager._instance._buttonClick += ButtonClicked;

		//Initialize a list of scores
		highscore = new List<Scores>();
	}



	void OnGUI () {
		textStyleTitle.fontSize = Screen.height / 50 * 4;
		GUI.skin = skin;

		// Title
		GUI.Label (new Rect (Screen.width / 2 - Screen.width/6, Screen.height/20, Screen.width/3, Screen.height/20*3), "High Scores", textStyleTitle);

		//GUI.Label (new Rect (Screen.width / 2 - Screen.width/4, Screen.height/20*3, Screen.width/2, Screen.height/20*3), "(this feature not implemented yet)", textStyleTitle);

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

		//Get the highscores
		highscore = HighScoreManager._instance.GetHighScore();

		GUILayout.Space(60);

		//Set the title for the name and score
		GUILayout.BeginHorizontal();
		GUILayout.Label("Name",textStyleTitle,GUILayout.Width(Screen.width/2));
		GUILayout.Label("Scores",textStyleTitle,GUILayout.Width(Screen.width/2));
		GUILayout.EndHorizontal();
		
		GUILayout.Space(25);
		//Go through each high score and print it to the screen
		textStyleTitle.fontSize = Screen.height / 50 * 3;
		foreach(Scores _score in highscore)
		{
			GUILayout.BeginHorizontal();
			GUILayout.Label(_score.name,textStyleTitle,GUILayout.Width(Screen.width/2));
			GUILayout.Label(""+_score.score,textStyleTitle,GUILayout.Width(Screen.width/2));
			GUILayout.EndHorizontal();

		}
	}
}