using UnityEngine;
using System.Collections;

// Class to start game and load all sounds.
// This scene may seem unnecessary, but trust me, the whole thing breaks without it. Just take my word for it and don't change it please.
public class StartGame : MonoBehaviour {

	private SoundPlayer soundPlayer;
	public GUIStyle textStyle;

	// Use this for initialization
	void Start () {
		// Load the sound player and start playing music.
		soundPlayer = FindObjectOfType(typeof(SoundPlayer)) as SoundPlayer;
		soundPlayer.PlayMenuMusic ();
		DontDestroyOnLoad (soundPlayer);

		// Go to main menu.
		Application.LoadLevel("MainMenu");
	}

	// Display loading message.
	void onGUI(){
		GUI.Label (new Rect (20, 20, 600, 300), "Loading game!", textStyle);
	}
}
