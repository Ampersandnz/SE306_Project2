using UnityEngine;
using System.Collections;

public class GUIStory : MonoBehaviour {

	private int iconWidth = 85;
	private int iconHeight = 75;
	private int textWidth = 150;

	public GUIStyle textStyle;
	public Texture2D opaqueHeartTexture;
	public Texture2D transparentHeartTexture;
	public Texture2D coinTexture;
	private PlayerStory player;

	public Texture2D wastedTexture;
	private int graphicWidth = 736;
	private int graphicHeight = 172;

	SoundPlayer soundPlayer;
	public GUIStyle textStyleButton;
	public GUISkin skin;
	public string musicSymbol;
	public string pauseSymbol;

	void Start() {
		player = FindObjectOfType(typeof(PlayerStory)) as PlayerStory;

		soundPlayer = FindObjectOfType(typeof(SoundPlayer)) as SoundPlayer;
		soundPlayer.PlayStoryMusic ();
		DontDestroyOnLoad (soundPlayer);
	}

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
		if(GUI.Button (new Rect(Screen.width/5*3, 0, 90, 90), pauseSymbol, textStyleButton)){
		}

		// Death screen
		if (player.playerDead == true) {
			GUI.Label (new Rect(Screen.width/2 - graphicWidth/2, Screen.height/2 - graphicHeight/2, graphicWidth, graphicHeight), wastedTexture);

			if(GUI.Button(new Rect(Screen.width/2-310,Screen.height/2+graphicHeight/2+20,300,90), "Restart", textStyleButton)) {
				Application.LoadLevel("StoryLevel1");
				soundPlayer.PlaySoundEffect ("menu");
			}

			if(GUI.Button(new Rect(Screen.width/2+10,Screen.height/2+graphicHeight/2+20,300,90), "Quit", textStyleButton)) {
				soundPlayer.PlayMenuMusic ();
				Application.LoadLevel("MainMenu");
				soundPlayer.PlaySoundEffect ("menu");
			}
		}
	}
}