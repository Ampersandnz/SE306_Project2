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

	// Initialising the death and end-of-level textures.
	public Texture2D deathTexture;
	public Texture2D levelFinishedTexture;
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

		textStyleButton.fontSize = Screen.height / 50 * 3;
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
		if(GUI.Button (new Rect(Screen.width/5*3, 0, Screen.height/20*2, Screen.height/20*4), pauseSymbol, textStyleButton)){
			if(player.playerDead == false && player.levelFinished == false){
				soundPlayer.PlaySoundEffect ("menu");
				pauseMenu.isPaused = true;
			}
		}

		// Death screen
		if (player.playerDead == true) {
			// Displaying the "game over" texture.
			GUI.Label (new Rect (Screen.width / 2 - graphicWidth / 2, Screen.height / 2 - graphicHeight / 2, graphicWidth, graphicHeight), deathTexture);

			// Button to restart the level.
			if (GUI.Button (new Rect (Screen.width / 2 - Screen.width/4 - Screen.width/50, Screen.height / 2 + graphicHeight/2 + Screen.height/30, Screen.width/4, Screen.height/20*3), "Restart", textStyleButton)) {
				Application.LoadLevel ("StoryLevel1");
				player.playerDead = false;
				pauseMenu.isPaused = false;
				soundPlayer.PlaySoundEffect ("menu");
				Time.timeScale = 1.0f;
			}

			// Button to quit back to menu.
			if (GUI.Button (new Rect (Screen.width / 2 + Screen.width/50, Screen.height / 2 + graphicHeight/2 + Screen.height/30, Screen.width/4, Screen.height/20*3), "Quit", textStyleButton)) {
				soundPlayer.PlayMenuMusic ();
				Application.LoadLevel ("Start");
				player.playerDead = false;
				pauseMenu.isPaused = false;
				soundPlayer.PlaySoundEffect ("menu");
				Time.timeScale = 1.0f;
			}

		} else if (player.levelFinished == true) { // If the player has reached the end of the level.
			Time.timeScale = 0.0f; // Stop time

			var boxWidth = Screen.width/2;
			var boxHeight = Screen.height/2;

			GUI.BeginGroup (new Rect (Screen.width / 2 - Screen.width/4, Screen.height / 2 - Screen.height/4, boxWidth, boxHeight),textStyle);
			// All rectangles are now adjusted to the group. (0,0) is the topleft corner of the group.
			
			// We'll make a box so you can see where the group is on-screen.
			GUI.Box (new Rect (0,0,boxWidth, boxHeight), "Level Cleared!", textStyle);

			// Displaying the "level finished" texture.
			//GUI.Label (new Rect (Screen.width / 2 - graphicWidth / 2, Screen.height / 2 - graphicHeight / 2, graphicWidth, graphicHeight), levelFinishedTexture);
			
			// Button to restart the level.
			if (GUI.Button (new Rect (boxWidth/8, boxHeight - boxHeight/4, boxWidth/4, boxHeight/4), "Restart", textStyleButton)) {
				soundPlayer.PlaySoundEffect ("menu");
				pauseMenu.isPaused = false;
				player.levelFinished = false;
				Application.LoadLevel ("StoryLevel1");
				Time.timeScale = 1.0f;
			}
			
			// Button to quit back to menu.
			if (GUI.Button (new Rect (boxWidth/8*3, boxHeight - boxHeight/4, boxWidth/4, boxHeight/4), "Quit", textStyleButton)) {
				soundPlayer.PlayMenuMusic ();
				pauseMenu.isPaused = false;
				player.levelFinished = false;
				Application.LoadLevel ("Start");
				soundPlayer.PlaySoundEffect ("menu");
				Time.timeScale = 1.0f;
			}

			// Button to go to next level
			if (GUI.Button (new Rect (boxWidth/8*5, boxHeight - boxHeight/4, boxWidth/3, boxHeight/4), "Next Level", textStyleButton)) {
				soundPlayer.PlaySoundEffect ("menu");
				pauseMenu.isPaused = false;
				player.levelFinished = false;
				Application.LoadLevel ("StoryLevel2");
				Time.timeScale = 1.0f;
			}

			// End the group we started above. This is very important to remember!
			GUI.EndGroup ();
		}
	}
}