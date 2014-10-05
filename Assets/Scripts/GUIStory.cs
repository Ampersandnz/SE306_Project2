using UnityEngine;
using System.Collections;

// Class to display the GUI in the story
public class GUIStory : MonoBehaviour {

	// Sizes of the text and icons
	private int iconWidth = 85;
	private int iconHeight = 75;
	private int textWidth = 150;

	// Initialising the textures and styles.
	public GUISkin skin;
	public GUIStyle textStyle;
	public GUIStyle textStyleButton;
	public Texture2D opaqueHeartTexture;
	public Texture2D transparentHeartTexture;
	public Texture2D coinTexture;

	// Initialising the "wasted" texture.
	public Texture2D wastedTexture;
	private int graphicWidth = 736;
	private int graphicHeight = 172;

	// Initialising sound player and text for sound buttons.
	SoundPlayer soundPlayer;
	public string musicSymbol;
	public string pauseSymbol;

	private PauseMenu pauseMenu; // Initialising reference to pause menu
	private PlayerStory player; // Initialising reference to player

	// Setting up references to player, pause menu and sound player
	void Start() {
		player = FindObjectOfType(typeof(PlayerStory)) as PlayerStory;
		pauseMenu = FindObjectOfType(typeof(PauseMenu)) as PauseMenu;

		soundPlayer = FindObjectOfType(typeof(SoundPlayer)) as SoundPlayer;
		soundPlayer.PlayStoryMusic ();
		DontDestroyOnLoad (soundPlayer);
	}

	// Displaying everything.
	void OnGUI () {
		
		// Health display
		int i = 0;

		while(i<player.health){
			GUI.Label (new Rect (10 + (i * (iconWidth + 10)), 10, iconWidth, iconHeight), opaqueHeartTexture);
			i++;
		}
		while (i<player.max_health) {
			GUI.Label (new Rect (10 + (i * (iconWidth + 10)), 10, iconWidth, iconHeight), transparentHeartTexture);
			i++;
		}

		// Coin display
		string coins = player.coins.ToString ();
		
		if (coins.Length == 1) {
			coins = "0" + coins;
		}
		
		coins = "×" + coins;
		GUI.Label (new Rect (Screen.width - (iconWidth + textWidth), 10, iconWidth, iconHeight), coinTexture);
		GUI.Label (new Rect (Screen.width - (10 + textWidth), 20, iconWidth, iconHeight), coins, textStyle);

		// Pause function
		if(GUI.Button (new Rect(Screen.width/5*3, 0, 50, 90), pauseSymbol, textStyleButton)){
			if(player.playerDead==false){
				pauseMenu.isPaused = true;
			}
		}

		// Death screen
		if (player.playerDead == true) {

			// Displaying the "wasted" texture.
			GUI.Label (new Rect(Screen.width/2 - graphicWidth/2, Screen.height/2 - graphicHeight/2, graphicWidth, graphicHeight), wastedTexture);

			// Button to restart the level.
			if(GUI.Button(new Rect(Screen.width/2-310,Screen.height/2+graphicHeight/2+20,300,90), "Restart", textStyleButton)) {
				Application.LoadLevel("StoryLevel1");
				soundPlayer.PlaySoundEffect ("menu");
			}

			// Button to quit back to menu.
			if(GUI.Button(new Rect(Screen.width/2+10,Screen.height/2+graphicHeight/2+20,300,90), "Quit", textStyleButton)) {
				soundPlayer.PlayMenuMusic ();
				Application.LoadLevel("MainMenu");
				soundPlayer.PlaySoundEffect ("menu");
			}
		}
	}
}