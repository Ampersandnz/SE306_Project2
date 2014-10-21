﻿using UnityEngine;
using System.Collections;

// Class to display the story level select menu
public class StoryLevelSelect : MonoBehaviour {
	private SoundPlayer soundPlayer;
	public GUIStyle textStyleTitle;
	public GUIStyle textStyleButton;
	public GUISkin skin;
	public string musicSymbol;
	public Texture2D oneStarTexture;
	public Texture2D twoStarsTexture;
	public Texture2D threeStarsTexture;
	public Texture2D lockTexture;
	private Texture2D starL1Texture; // stores star texture to display for L1
	private Texture2D starL2Texture; // stores star texture to display for L2
	private Texture2D starL3Texture; // stores star texture to display for L3

	public static int currentLevel;


	// Load sound player
	void Start(){
		soundPlayer = FindObjectOfType(typeof(SoundPlayer)) as SoundPlayer;
		DontDestroyOnLoad (soundPlayer);
		
		textStyleTitle.fontSize = Screen.height / 50 * 4;
		textStyleButton.fontSize = Screen.height / 50 * 3;
	}

	// Display everything
	void OnGUI () {
		GUI.skin = skin;

		// Display title
		GUI.Label (new Rect (Screen.width / 2 - Screen.width/6, Screen.height/20, Screen.width/3, Screen.height/20*3), "Story mode", textStyleTitle);

		// Button for level 1
		if(GUI.Button(new Rect(Screen.width/2-Screen.width/6, Screen.height/20*3 , Screen.width/3, Screen.height/20*3), "Level 1", textStyleButton)) {
			currentLevel = 1;
			Application.LoadLevel("StoryLevel1");
			soundPlayer.PlaySoundEffect ("menu");
		}
<<<<<<< HEAD
		
=======

>>>>>>> feature/stars
		// Display stars for level 1
		if (PlayerPrefs.GetInt ("SwiperStarsL1") != 0) {
			if (PlayerPrefs.GetInt ("SwiperStarsL1") == 1) {
				starL1Texture = oneStarTexture;
			} else if (PlayerPrefs.GetInt ("SwiperStarsL1") == 2) {
				starL1Texture = twoStarsTexture;
			} else if (PlayerPrefs.GetInt ("SwiperStarsL1") == 3) {
				starL1Texture = threeStarsTexture;
			}
			GUI.Label (new Rect (Screen.width / 2 + Screen.width / 20, Screen.height / 40 * 7, Screen.width / 3, Screen.height / 20 * 2), starL1Texture);
		}
<<<<<<< HEAD
		
=======

>>>>>>> feature/stars
		// Button for level 2
		if(GUI.Button(new Rect(Screen.width/2-Screen.width/6, Screen.height/20*3 + Screen.height/10, Screen.width/3, Screen.height/20*3), "Level 2", textStyleButton)) {
			if (PlayerPrefs.GetInt ("SwiperStarsL1") > 1) { // Enable button if enough stars
				currentLevel = 2;
				Application.LoadLevel("StoryLevel2");
				soundPlayer.PlaySoundEffect ("menu");
			}
<<<<<<< HEAD
=======
		}

		// Display lock on level 2 if not enough stars on level 1
		if (PlayerPrefs.GetInt ("SwiperStarsL1") < 2) {
			GUI.Label (new Rect (Screen.width / 2 + Screen.width / 12, Screen.height / 20 * 3 + Screen.height / 10, Screen.width / 3, Screen.height / 20 * 3), lockTexture);
		}
		
		 // Display stars for level 2
		if (PlayerPrefs.GetInt ("SwiperStarsL2") != 0) {
			if (PlayerPrefs.GetInt ("SwiperStarsL2") == 1) {
				starL2Texture = oneStarTexture;
			} else if (PlayerPrefs.GetInt ("SwiperStarsL2") == 2) {
				starL2Texture = twoStarsTexture;
			} else if (PlayerPrefs.GetInt ("SwiperStarsL2") == 3) {
				starL2Texture = threeStarsTexture;
			}
			GUI.Label (new Rect (Screen.width / 2 + Screen.width / 20, Screen.height / 40 * 7 + Screen.height/10, Screen.width / 3, Screen.height / 20 * 2), starL2Texture);
>>>>>>> feature/stars
		}
		
		// Display lock on level 2 if not enough stars on level 1
		if (PlayerPrefs.GetInt ("SwiperStarsL1") < 2) {
			GUI.Label (new Rect (Screen.width / 2 + Screen.width / 12, Screen.height / 20 * 3 + Screen.height / 10, Screen.width / 3, Screen.height / 20 * 3), lockTexture);
		}
		
		// Display stars for level 2
		if (PlayerPrefs.GetInt ("SwiperStarsL2") != 0) {
			if (PlayerPrefs.GetInt ("SwiperStarsL2") == 1) {
				starL2Texture = oneStarTexture;
			} else if (PlayerPrefs.GetInt ("SwiperStarsL2") == 2) {
				starL2Texture = twoStarsTexture;
			} else if (PlayerPrefs.GetInt ("SwiperStarsL2") == 3) {
				starL2Texture = threeStarsTexture;
			}
			GUI.Label (new Rect (Screen.width / 2 + Screen.width / 20, Screen.height / 40 * 7 + Screen.height/10, Screen.width / 3, Screen.height / 20 * 2), starL2Texture);
		}
		
		// Button for level 3
		if(GUI.Button(new Rect(Screen.width/2-Screen.width/6, Screen.height/20*3 + Screen.height/10*2, Screen.width/3, Screen.height/20*3), "Level 3", textStyleButton)) {
			if (PlayerPrefs.GetInt ("SwiperStarsL2") > 1) { // Enable button if enough stars
				currentLevel = 3;
				Application.LoadLevel("StoryLevel3");
				soundPlayer.PlaySoundEffect ("menu");
			}
		}
<<<<<<< HEAD
		
=======

>>>>>>> feature/stars
		// Display lock on level 3 if not enough stars on level 2
		if (PlayerPrefs.GetInt ("SwiperStarsL2") < 2) {
			GUI.Label (new Rect (Screen.width / 2 + Screen.width / 12, Screen.height / 20 * 3 + Screen.height / 10 * 2, Screen.width / 3, Screen.height / 20 * 3), lockTexture);
		}
		
		// Display stars for level 3
		if (PlayerPrefs.GetInt ("SwiperStarsL3") != 0) {
			if (PlayerPrefs.GetInt ("SwiperStarsL3") == 1) {
				starL3Texture = oneStarTexture;
			} else if (PlayerPrefs.GetInt ("SwiperStarsL3") == 2) {
				starL3Texture = twoStarsTexture;
			} else if (PlayerPrefs.GetInt ("SwiperStarsL3") == 3) {
				starL3Texture = threeStarsTexture;
			}
			GUI.Label (new Rect (Screen.width / 2 + Screen.width / 20, Screen.height / 40 * 7 + Screen.height/10*2, Screen.width / 3, Screen.height / 20 * 2), starL3Texture);
		}

		// Button to go back to main menu
		if((GUI.Button(new Rect(Screen.width/2-Screen.width/6, Screen.height/20*3 + Screen.height/10*3, Screen.width/3, Screen.height/20*3), "Back", textStyleButton)) || (Input.GetKeyDown(KeyCode.Escape))) {
			Application.LoadLevel("MainMenu");
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
	}
}
