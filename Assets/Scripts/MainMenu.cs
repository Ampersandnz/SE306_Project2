using UnityEngine;
using System.Collections;

// Class to display main menu.
public class MainMenu : MonoBehaviour {

	private SoundPlayer soundPlayer;
	public Texture2D logo;
	public GUIStyle textStyleButton;
	public GUIStyle textStyleLabel;
	public GUISkin skin;
	public string musicSymbol;
	public string disclaimer;
	public Texture2D lockTexture;

	// Loading sound player
	void Start(){
		soundPlayer = FindObjectOfType(typeof(SoundPlayer)) as SoundPlayer;
		DontDestroyOnLoad (soundPlayer);

		textStyleLabel.fontSize = Screen.height / 50;
		textStyleButton.fontSize = Screen.height / 50 * 3;
		disclaimer = "DISCLAIMER: The makers of this game do not own any intellectual property associated with the Dora the Explorer franchise, which belongs to Nickelodeon, and whom we have no affiliation with. This is purely a fan-made project for entertainment purposes only. This game does not seek financial gain, does not aim to be distributed, does not attempt to substitute for the original work, and contains only a limited portion of the Dora the Explorer TV show.";
	}

	// Displaying everything
	void OnGUI () {
		GUI.skin = skin;

		// Displaying logo
		if (Screen.width > 1200) {
			GUI.Label (new Rect (Screen.width / 2 - 250, 0, 500, Screen.height / 12 * 7), logo);
		}else{
			GUI.Label (new Rect (Screen.width / 2 - Screen.width / 24 * 5, 0, Screen.width / 12 * 5, Screen.height / 12 * 7), logo);
		}

		// Button to go to story level select menu
		if(GUI.Button(new Rect(Screen.width/2-Screen.width/6, Screen.height/12*5+Screen.height/20, Screen.width/3, Screen.height/20*3), "Story mode", textStyleButton)) {
			Application.LoadLevel("StoryLevelSelect");
			soundPlayer.PlaySoundEffect ("menu");
		}

		// Button to go to endless runner mode menu
		if(GUI.Button(new Rect(Screen.width/2-Screen.width/6, Screen.height/12*5+Screen.height/20*3, Screen.width/3, Screen.height/20*3), "Endless mode", textStyleButton)) {
			// Enable button only if two or three stars achieved in all levels
			if ((PlayerPrefs.GetInt ("SwiperStarsL1") + PlayerPrefs.GetInt ("SwiperStarsL2") + PlayerPrefs.GetInt ("SwiperStarsL3")) > 6) {
				Application.LoadLevel("EndlessRunnerMode");
				soundPlayer.PlaySoundEffect ("menu");
			}
		}
		
		// Display lock if not enough stars achieved in story mode levels
		if ((PlayerPrefs.GetInt ("SwiperStarsL1") + PlayerPrefs.GetInt ("SwiperStarsL2") + PlayerPrefs.GetInt ("SwiperStarsL3")) < 7) {
			GUI.Label (new Rect (Screen.width/2+ Screen.width/11, Screen.height/12*5+Screen.height/20*3, Screen.width / 3, Screen.height / 20 * 3), lockTexture);
		}

		// Button to see credits
		if(GUI.Button(new Rect(Screen.width/2-Screen.width/6, Screen.height/12*5+Screen.height/20*5 , Screen.width/3, Screen.height/20*3), "Credits", textStyleButton)) {
			Application.LoadLevel("Credits");
			soundPlayer.PlaySoundEffect ("menu");
		}

		// Disclaimer.
		GUI.Label (new Rect (Screen.width / 4, Screen.height / 6 * 5, Screen.width / 2, Screen.height / 6), disclaimer, textStyleLabel);

		// Button to toggle music
		if(GUI.Button(new Rect(Screen.width-Screen.width/24*5,Screen.height/30, Screen.width/12, Screen.height/20*3), musicSymbol, textStyleButton)) {
			soundPlayer.PlaySoundEffect ("menu");
			soundPlayer.ToggleMusic("menu");
		}

		// Button to toggle sound effects
		if(GUI.Button(new Rect(Screen.width-Screen.width/60*7, Screen.height/30, Screen.width/120*11, Screen.height/20*3), "sfx", textStyleButton)) {
			soundPlayer.PlaySoundEffect ("menu");
			soundPlayer.ToggleSound();
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit();
		}
	}
}