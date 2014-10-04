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

	void Start() {
		player = FindObjectOfType(typeof(PlayerStory)) as PlayerStory;

		SoundPlayer soundPlayer = FindObjectOfType(typeof(SoundPlayer)) as SoundPlayer;
		soundPlayer.PlayStoryMusic ();
		DontDestroyOnLoad (soundPlayer);
	}

	void OnGUI () {
		string coins = player.coins.ToString ();

		if (coins.Length == 1) {
			coins = "0" + coins;
		}

		coins = "× " + coins;

		int i = 0;

		while(i<player.health){
			GUI.Label (new Rect (10 + (i * (iconWidth + 15)), 10, iconWidth, iconHeight), opaqueHeartTexture);
			i++;
		}
		while (i<player.max_health) {
			GUI.Label (new Rect (10 + (i * (iconWidth + 15)), 10, iconWidth, iconHeight), transparentHeartTexture);
			i++;
		}
		
		GUI.Label (new Rect (Screen.width - (10 + iconWidth + textWidth), 10, iconWidth, iconHeight), coinTexture);
		GUI.Label (new Rect (Screen.width - (10 + textWidth), 10, iconWidth, iconHeight), coins, textStyle);

		if (player.playerDead == true) {
			GUI.Label (new Rect(Screen.width/2 - graphicWidth/2, Screen.height/2 - graphicHeight/2, graphicWidth, graphicHeight), wastedTexture);
			if(GUI.Button(new Rect(Screen.width/2-50,Screen.height/2+graphicHeight/2+20,200,80), "Restart")) {
				Application.LoadLevel("StoryLevel1");
			}
		}
	}
}