using UnityEngine;
using System.Collections;

public class StoryLevelSelect : MonoBehaviour {
	private SoundPlayer soundPlayer;
	public GUIStyle textStyleTitle;
	public GUIStyle textStyleButton;
	public GUISkin skin;
	public string musicSymbol;
	
	void Start(){
		soundPlayer = FindObjectOfType(typeof(SoundPlayer)) as SoundPlayer;
		DontDestroyOnLoad (soundPlayer);
	}

	void OnGUI () {
		GUI.skin = skin;
		
		GUI.Label (new Rect (Screen.width / 2 - 150, 50, 300, 90), "Story mode", textStyleTitle);
		
		if(GUI.Button(new Rect(Screen.width/2-150, 90 , 300,90), "Level 1", textStyleButton)) {
			Application.LoadLevel("StoryLevel1");
			soundPlayer.PlaySoundEffect ("menu");
		}
		
		if(GUI.Button(new Rect(Screen.width/2-150, 150 , 300,90), "Level 2", textStyleButton)) {
			Application.LoadLevel("StoryLevel2");
			soundPlayer.PlaySoundEffect ("menu");
		}
		
		if(GUI.Button(new Rect(Screen.width/2-150, 210 , 300,90), "Level 3", textStyleButton)) {
			Application.LoadLevel("StoryLevel3");
			soundPlayer.PlaySoundEffect ("menu");
		}

		if(GUI.Button(new Rect(Screen.width/2-150, 270 , 300,90), "Back", textStyleButton)) {
			Application.LoadLevel("MainMenu");
			soundPlayer.PlaySoundEffect ("menu");
		}

		if(GUI.Button(new Rect(Screen.width-250,20,100,90), musicSymbol, textStyleButton)) {
			// Toggle mute/unmute of music
			soundPlayer.PlaySoundEffect ("menu");
			soundPlayer.ToggleMusic();
		}
		
		if(GUI.Button(new Rect(Screen.width-140,20,110,90), "sfx", textStyleButton)) {
			// Toggle mute/unmute of game sounds
			soundPlayer.PlaySoundEffect ("menu");
			soundPlayer.ToggleSound();
		}
	}
}
