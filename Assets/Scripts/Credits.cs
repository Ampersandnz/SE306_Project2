using UnityEngine;
using System.Collections;

// Class to display the credits.
public class Credits : MonoBehaviour {
	private SoundPlayer soundPlayer;
	public GUIStyle textStyleTitle;
	public GUIStyle textStyleButton;
	public GUIStyle textStyleBody;
	public GUISkin skin;
	public string musicSymbol;

	private string credits;
	private Vector2 scrollPosition;

	// Loading sound player and initialising credits text.
	void Start(){
		soundPlayer = FindObjectOfType(typeof(SoundPlayer)) as SoundPlayer;
		DontDestroyOnLoad (soundPlayer);
		credits = "Programmed by:\n\n- Taz Hussain\n- Nikita Kabra\n- Richa Patel\n- Brian Cham\n- Shivarni Bhavan\n Rione Naidoo\n- Luman Wang\n- Michael Lo\n- Sufiyaan Mitha";
		credits += "\n\nMusic used:\n\n- Menu song - Swiper no Swiping by Krazy Obilla\n- Background song - Dora the Explorer theme";
		credits += "\n\nSound effects:\n\n- Applause by Joe Deshon\n- Bounce by Denis Chapon\n- Cash register by Kidd Park\n- Crunch by Ram Stush\n- Health by Iwan Gabovitch\n- Hit by _jack\n- Menu select by Nemad Simic\n- 'Oh man' from Dora the Explorer";
		credits += "\n\nWe are not affiliated with Nickelodeon. This is purely a fanmade project. We do not claim ownership of any intellectual property associated with Dora the Explorer.";
		credits += "\n\nCC BY-3";
		scrollPosition = Vector2.zero;
		
		textStyleTitle.fontSize = Screen.height / 50 * 4;
		textStyleButton.fontSize = Screen.height / 50 * 3;
		textStyleBody.fontSize = Screen.height / 50 * 2;
	}

	// Displaying everything.
	void OnGUI () {
		GUI.skin = skin;

		// Title
		GUI.Label (new Rect (Screen.width / 2 - Screen.width/6, Screen.height/20, Screen.width/3, Screen.height/20*3), "Credits", textStyleTitle);

		// Scrollable credits area
		GUILayout.BeginArea (new Rect(Screen.width/2-Screen.width/80*17, Screen.height/60*13, Screen.width/12*5, Screen.height/2));
			scrollPosition = GUILayout.BeginScrollView (scrollPosition, GUILayout.MaxWidth (Screen.width/12*5), GUILayout.ExpandWidth (false));
			GUILayout.Label (credits, textStyleBody, GUILayout.ExpandWidth (true));
			GUILayout.EndScrollView ();
		GUILayout.EndArea ();

		// Back button
		if(GUI.Button(new Rect(Screen.width/2-Screen.width/8, Screen.height/60*43, Screen.width/4, Screen.height/20*3), "Back", textStyleButton)) {
			Application.LoadLevel("MainMenu");
			soundPlayer.PlaySoundEffect ("menu");
		}

		// Music toggle
		if(GUI.Button(new Rect(Screen.width-Screen.width/24*5,Screen.height/30, Screen.width/12 , Screen.height/20*3), musicSymbol, textStyleButton)) {
			// Toggle mute/unmute of music
			soundPlayer.PlaySoundEffect ("menu");
			soundPlayer.ToggleMusic("menu");
		}

		// Sound toggle
		if(GUI.Button(new Rect(Screen.width-Screen.width/60*7, Screen.height/30, Screen.width/120*11, Screen.height/20*3), "sfx", textStyleButton)) {
			// Toggle mute/unmute of game sounds
			soundPlayer.PlaySoundEffect ("menu");
			soundPlayer.ToggleSound();
		}
	}
}