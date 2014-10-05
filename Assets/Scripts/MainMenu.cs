using UnityEngine;
using System.Collections;

// Class to display main menu.
public class MainMenu : MonoBehaviour {

	private SoundPlayer soundPlayer;
	public Texture2D logo;
	public GUIStyle textStyle;
	public GUISkin skin;
	public string musicSymbol;


	// Loading sound player
	void Start(){
		soundPlayer = FindObjectOfType(typeof(SoundPlayer)) as SoundPlayer;
		DontDestroyOnLoad (soundPlayer);
	}


	// Displaying everything
	void OnGUI () {
		GUI.skin = skin;

		// Displaying logo
		GUI.Label (new Rect(Screen.width/2-250, 0,500,338), logo);

		// Button to go to story level select menu
		if(GUI.Button(new Rect(Screen.width/2-150, 330 , 300,90), "Story mode", textStyle)) {
			Application.LoadLevel("StoryLevelSelect");
			soundPlayer.PlaySoundEffect ("menu");
		}

		// Button to go to endless runner mode menu
		if(GUI.Button(new Rect(Screen.width/2-150, 390 , 300,90), "Endless mode", textStyle)) {
			Application.LoadLevel("EndlessRunnerMode");
			soundPlayer.PlaySoundEffect ("menu");
		}

		// Button to see credits
		if(GUI.Button(new Rect(Screen.width/2-150, 450 , 300,90), "Credits", textStyle)) {
			Application.LoadLevel("Credits");
			soundPlayer.PlaySoundEffect ("menu");
		}

		// Button to toggle music
		if(GUI.Button(new Rect(Screen.width-250,20,100,90), musicSymbol, textStyle)) {
			soundPlayer.PlaySoundEffect ("menu");
			soundPlayer.ToggleMusic("menu");
		}

		// Button to toggle sound effects
		if(GUI.Button(new Rect(Screen.width-140,20,110,90), "sfx", textStyle)) {
			// Toggle mute/unmute of game sounds
			soundPlayer.PlaySoundEffect ("menu");
			soundPlayer.ToggleSound();
		}
	}
}