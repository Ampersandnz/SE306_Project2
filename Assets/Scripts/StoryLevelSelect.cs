using UnityEngine;
using System.Collections;

public class StoryLevelSelect : MonoBehaviour {
	private SoundPlayer soundPlayer;
	
	void Start(){
		soundPlayer = FindObjectOfType(typeof(SoundPlayer)) as SoundPlayer;
		DontDestroyOnLoad (soundPlayer);
	}

	void OnGUI () {
		GUI.Box(new Rect(10,10,100,150), "Story mode");

		if(GUI.Button(new Rect(20,40,80,20), "Level 1")) {
			Application.LoadLevel("StoryLevel1");
			soundPlayer.PlaySoundEffect("menu");
		}

		if(GUI.Button(new Rect(20,70,80,20), "Level 2")) {
			Application.LoadLevel("StoryLevel2");
			soundPlayer.PlaySoundEffect("menu");
		}

		if(GUI.Button(new Rect(20,100,80,20), "Level 3")) {
			Application.LoadLevel("StoryLevel3");
			soundPlayer.PlaySoundEffect("menu");
		}

		if(GUI.Button(new Rect(20,130,80,20), "Back")) {
			Application.LoadLevel("MainMenu");
			soundPlayer.PlaySoundEffect("menu");
		}
	}
}
