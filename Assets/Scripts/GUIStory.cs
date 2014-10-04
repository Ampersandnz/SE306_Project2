using UnityEngine;
using System.Collections;

public class GUIStory : MonoBehaviour {

	private int iconWidth = 85;
	private int iconHeight = 75;
	private int textWidth = 150;

	public GUIStyle textStyle;
	public Texture2D heartTexture;
	public Texture2D coinTexture;
	private PlayerStory player;

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

		for (int i = 0; i < player.health; i++) {
			GUI.Label (new Rect (10 + (i * (iconWidth + 15)), 10, iconWidth, iconHeight), heartTexture);
		}
		
		GUI.Label (new Rect (Screen.width - (10 + iconWidth + textWidth), 10, iconWidth, iconHeight), coinTexture);
		GUI.Label (new Rect (Screen.width - (10 + textWidth), 10, iconWidth, iconHeight), coins, textStyle);
	}
}