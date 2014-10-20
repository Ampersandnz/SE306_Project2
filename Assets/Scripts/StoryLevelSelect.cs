using UnityEngine;
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
	private Texture2D starTexture; // stores star texture to display

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

		//Check what stars are stored
		if (PlayerPrefs.GetInt ("Stars") == 1) {
			starTexture = oneStarTexture;
		} else if (PlayerPrefs.GetInt ("Stars") == 2) {
			starTexture = twoStarsTexture;
		} else if (PlayerPrefs.GetInt ("Stars") == 3) {
			starTexture = threeStarsTexture;
		}

		GUI.Label (new Rect (Screen.width / 2, Screen.height / 20 * 3, Screen.width / 3, Screen.height / 20 * 3), starTexture);
				


		// Button for level 2
		if(GUI.Button(new Rect(Screen.width/2-Screen.width/6, Screen.height/20*3 + Screen.height/10, Screen.width/3, Screen.height/20*3), "Level 2", textStyleButton)) {
			currentLevel = 2;
			Application.LoadLevel("StoryLevel2");
			soundPlayer.PlaySoundEffect ("menu");
		}

		// Button for level 3
		if(GUI.Button(new Rect(Screen.width/2-Screen.width/6, Screen.height/20*3 + Screen.height/10*2, Screen.width/3, Screen.height/20*3), "Level 3", textStyleButton)) {
			currentLevel = 3;
			Application.LoadLevel("StoryLevel3");
			soundPlayer.PlaySoundEffect ("menu");
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
