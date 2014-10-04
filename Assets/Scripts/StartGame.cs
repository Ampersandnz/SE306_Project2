using UnityEngine;
using System.Collections;

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

	void onGUI(){
		GUI.Label (new Rect (20, 20, 600, 300), "Loading game!", textStyle);
	}
}
