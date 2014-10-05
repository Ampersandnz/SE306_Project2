using UnityEngine;
using System.Collections;

// Class to display the story level select menu
public class StoryLevelSelect : MonoBehaviour {
	private SoundPlayer soundPlayer;
	public GUIStyle textStyleTitle;
	public GUIStyle textStyleButton;
	public GUISkin skin;
	public string musicSymbol;

	// Load sound player
	void Start(){
		soundPlayer = FindObjectOfType(typeof(SoundPlayer)) as SoundPlayer;
		DontDestroyOnLoad (soundPlayer);
	}

	// Display everything
	void OnGUI () {
		GUI.skin = skin;

		// Display title
		GUI.Label (new Rect (Screen.width / 2 - 150, 50, 300, 90), "Story mode", textStyleTitle);

		// Button for level 1
		if(GUI.Button(new Rect(Screen.width/2-150, 90 , 300,90), "Level 1", textStyleButton)) {
			Application.LoadLevel("StoryLevel1");
			soundPlayer.PlaySoundEffect ("menu");
		}

		// Button for level 2
		if(GUI.Button(new Rect(Screen.width/2-150, 150 , 300,90), "Level 2", textStyleButton)) {
			Application.LoadLevel("StoryLevel2");
			soundPlayer.PlaySoundEffect ("menu");
		}

		// Button for level 3
		if(GUI.Button(new Rect(Screen.width/2-150, 210 , 300,90), "Level 3", textStyleButton)) {
			Application.LoadLevel("StoryLevel3");
			soundPlayer.PlaySoundEffect ("menu");
		}

		// Button to go back to main menu
		if(GUI.Button(new Rect(Screen.width/2-150, 270 , 300,90), "Back", textStyleButton)) {
			Application.LoadLevel("MainMenu");
			soundPlayer.PlaySoundEffect ("menu");
		}

		// Button to toggle music
		if(GUI.Button(new Rect(Screen.width-250,20,100,90), musicSymbol, textStyleButton)) {
			soundPlayer.PlaySoundEffect ("menu");
			soundPlayer.ToggleMusic("menu");
		}

		// Button to toggle sound effects
		if(GUI.Button(new Rect(Screen.width-140,20,110,90), "sfx", textStyleButton)) {
			soundPlayer.PlaySoundEffect ("menu");
			soundPlayer.ToggleSound();
		}
	}
}
