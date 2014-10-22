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
		
		// Unlock all the levels if the user paid
		if (PlayerPrefs.HasKey ("SwiperPaidUnlockAllLevels")) {
		//14090607 is the code associated to unlock all levels
			if(PlayerPrefs.GetInt("SwiperPaidUnlockAllLevels")==14090607){
				PlayerPrefs.SetInt("SwiperStarsL1",3);
				PlayerPrefs.SetInt("SwiperStarsL2",3);
				PlayerPrefs.SetInt("SwiperStarsL3",3);
				//Endless Runner will unlock since there are more than 7 stars
			}
		}

	}

	// Display loading message.
	void onGUI(){
		GUI.Label (new Rect (20, 20, 600, 300), "Loading game!", textStyle);
	}
}
