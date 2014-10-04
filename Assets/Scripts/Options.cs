using UnityEngine;
using System.Collections;

public class Options : MonoBehaviour {
	private SoundPlayer soundPlayer;

	void Start(){
		soundPlayer = FindObjectOfType(typeof(SoundPlayer)) as SoundPlayer;
		DontDestroyOnLoad (soundPlayer);
	}

	void OnGUI () {
		GUI.Box(new Rect(10,10,100,120), "Menu");

		if(GUI.Button(new Rect(20,40,80,20), "Music")) {
			// Toggle mute/unmute of music
			soundPlayer.PlaySoundEffect ("menu");
			soundPlayer.ToggleMusic();
		}

		if(GUI.Button(new Rect(20,70,80,20), "Sound")) {
			// Toggle mute/unmute of game sounds
			soundPlayer.PlaySoundEffect ("menu");
			soundPlayer.ToggleSound();
		}

		if(GUI.Button(new Rect(20,100,80,20), "Back")) {
			Application.LoadLevel("MainMenu");
			soundPlayer.PlaySoundEffect ("menu");
		}
	}
}