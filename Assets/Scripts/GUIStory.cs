using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Class to display the GUI in the story
public class GUIStory : MonoBehaviour {

	// Get the name of the current level
	public string thisLevel;

	// Sizes of the text and icons
	private int iconWidth = 85;
	private int iconHeight = 75;
	private int textWidth = 150;

	// Initialising the textures and styles.
	public GUISkin skin;
	public GUIStyle textStyle;
	public GUIStyle textStyleButton;
	public GUIStyle boxStyle;
	public Texture2D opaqueHeartTexture;
	public Texture2D transparentHeartTexture;
	public Texture2D coinTexture;
	public Texture2D oneStarTexture;
	public Texture2D twoStarsTexture;
	public Texture2D threeStarsTexture;

	// Initialising the death and end-of-level textures.
	public Texture2D deathTexture;
	public Texture2D endOfLevelTexture;
	private int graphicWidth = 736;
	private int graphicHeight = 172;

	// Initialising sound player and text for sound buttons.
	SoundPlayer soundPlayer;
	public string musicSymbol;
	public string pauseSymbol;

	private List<int> level1Stars = new List<int>(new int[] {12, 20}); 	// Coin values for two and three stars in Level 1
	private List<int> level2Stars = new List<int>(new int[] {20, 30}); 	// Coin values for two and three stars in Level 2
	private List<int> level3Stars = new List<int>(new int[] {25, 44}); 	// Coin values for two and three stars in Level 3
	private Texture2D starTexture; // stores star texture to display
	private bool enoughStars = false;

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

		thisLevel = Application.loadedLevelName;
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
				if(StoryLevelSelect.currentLevel == 1){
					Application.LoadLevel ("StoryLevel1");
				}else if (StoryLevelSelect.currentLevel == 2){
					Application.LoadLevel ("StoryLevel2");
				}else if (StoryLevelSelect.currentLevel == 3){
					Application.LoadLevel ("StoryLevel3");
				}
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
			
			var boxWidth = Screen.width/8*5;
			var boxHeight = Screen.height/2;
			
			GUI.BeginGroup (new Rect (Screen.width/2-boxWidth/2, Screen.height / 2 - boxHeight/2, boxWidth, boxHeight),boxStyle);
			
			GUI.Label (new Rect (0,-32,boxWidth, boxHeight), endOfLevelTexture);

			string levelName = Application.loadedLevelName;

			// Check what level we are in and display stars based on how many coins collected
			if (levelName == "StoryLevel1") {
				if (player.coins >= level1Stars[1]) { // three stars
					starTexture = threeStarsTexture;
					enoughStars = true;
				} else if (player.coins < level1Stars[0]) { // one star
					starTexture = oneStarTexture;
					enoughStars = false;
				} else { // two stars
					starTexture = twoStarsTexture;
					enoughStars = true;
				}
			} else if (levelName == "StoryLevel2") {
				if (player.coins >= level2Stars[1]) { // three stars
					starTexture = threeStarsTexture;
					enoughStars = true;
				} else if (player.coins < level2Stars[0]) { // one star
					starTexture = oneStarTexture;
					enoughStars = false;
				} else { // two stars
					starTexture = twoStarsTexture;
					enoughStars = true;
				}
			} else if (levelName == "StoryLevel3") {
				if (player.coins >= level3Stars[1]) { // three stars
					starTexture = threeStarsTexture;
					enoughStars = true;
				} else if (player.coins < level3Stars[0]) { // one star
					starTexture = oneStarTexture;
					enoughStars = false;
				} else { // two stars
					starTexture = twoStarsTexture;
					enoughStars = true;
				}
			}
			
			GUI.Label (new Rect(boxWidth/3, boxHeight/3, boxWidth/10*4, boxHeight/10*4), starTexture); // display stars
			
			// Button to restart the level.
			if (GUI.Button (new Rect (boxWidth/8, boxHeight - boxHeight/5, boxWidth/4, boxHeight/4), "Restart", textStyleButton)) {
				soundPlayer.PlaySoundEffect ("menu");
				pauseMenu.isPaused = false;
				player.levelFinished = false;
				Application.LoadLevel ("StoryLevel1");
				Time.timeScale = 1.0f;
			}
			
			// Button to quit back to menu.
			if (GUI.Button (new Rect (boxWidth/8*3, boxHeight - boxHeight/5, boxWidth/4, boxHeight/4), "Quit", textStyleButton)) {
				soundPlayer.PlayMenuMusic ();
				pauseMenu.isPaused = false;
				player.levelFinished = false;
				Application.LoadLevel ("Start");
				soundPlayer.PlaySoundEffect ("menu");
				Time.timeScale = 1.0f;
			}
			
			// Button to go to next level if two or three stars achieved
			if (GUI.Button (new Rect (boxWidth/8*5, boxHeight - boxHeight/5, boxWidth/3, boxHeight/4), "Next Level", textStyleButton)) {
				if (enoughStars) {	
					soundPlayer.PlaySoundEffect ("menu");
					pauseMenu.isPaused = false;
					player.levelFinished = false;

					// Load the next level depending on what level we are already on.
					// TODO - Change to the storyboard scenes instead.
					if(thisLevel=="StoryLevel1"){
						Application.LoadLevel ("EndOfLevel1");
					} else if (thisLevel =="StoryLevel2"){
						Application.LoadLevel ("EndOfLevel2");
					} else if (thisLevel=="StoryLevel3"){
						Application.LoadLevel ("Level3End1");
					}

					Time.timeScale = 1.0f;
				}
			}
			
			// End the group we started above. This is very important to remember!
			GUI.EndGroup ();
		}
	}
}