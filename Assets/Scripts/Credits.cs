using UnityEngine;
using System.Collections;

// Class to display the credits.
public class Credits : MonoBehaviour {
	private SoundPlayer soundPlayer;
	public GUIStyle textStyleTitle;
	public GUIStyle textStyleButton;
	public GUIStyle textStyleBody;
	public GUISkin skin;

	private bool hasMusic = SoundPlayer.music;
	private bool hasSound = SoundPlayer.sound;
	public Texture2D noMusic, music, noSound, sound;

	private string credits;
	private Vector2 scrollPosition;

	// Loading sound player and initialising credits text.
	void Start(){
		soundPlayer = FindObjectOfType(typeof(SoundPlayer)) as SoundPlayer;
		DontDestroyOnLoad (soundPlayer);
		credits = "Programmed by:\n\n- Tasneef Hussain\n- Nikita Kabra\n- Richa Patel\n- Brian Cham\n- Shivarni Bhavan\n Rione Naidoo\n- Luman Wang\n- Michael Lo\n- Sufiyaan Mitha";
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
		if((GUI.Button(new Rect(Screen.width/2-Screen.width/4, Screen.height/60*43, Screen.width/4, Screen.height/20*3), "Back", textStyleButton)) || (Input.GetKeyDown(KeyCode.Escape))) {
			Application.LoadLevel("MainMenu");
			soundPlayer.PlaySoundEffect ("menu");
		}
		//Cheat button
		if(GUI.Button(new Rect(Screen.width/2+Screen.width/50, Screen.height/60*43, Screen.width/4, Screen.height/20*3), "Cheat", textStyleButton)) {
			Application.LoadLevel("Cheat");
			soundPlayer.PlaySoundEffect ("menu");
		}

		// Button to toggle music
		if (hasMusic == true) {
			if (GUI.Button (new Rect (Screen.width - Screen.width / 27 * 5, Screen.height / 20 , Screen.width / 25, Screen.height / 20 * 3), music, textStyleButton)) {
				soundPlayer.PlaySoundEffect ("menu");
				hasMusic = soundPlayer.ToggleMusic ("menu");
			}
		} else {
			if (GUI.Button (new Rect (Screen.width - Screen.width / 27 * 5, Screen.height / 20 , Screen.width / 25, Screen.height / 20 * 3), noMusic, textStyleButton)) {
				soundPlayer.PlaySoundEffect ("menu");
				hasMusic = soundPlayer.ToggleMusic ("menu");
			}
		}
		
		
		if (hasSound == true) {
			if(GUI.Button(new Rect(Screen.width-Screen.width/60*7, Screen.height/20, Screen.width / 25, Screen.height / 20 * 3), sound, textStyleButton)){
				soundPlayer.PlaySoundEffect ("menu");
				hasSound = soundPlayer.ToggleSound();
			}
		} else {
			if(GUI.Button(new Rect(Screen.width-Screen.width/60*7, Screen.height/20, Screen.width / 25, Screen.height / 20 * 3), noSound, textStyleButton)) {
				soundPlayer.PlaySoundEffect ("menu");
				hasSound = soundPlayer.ToggleSound();
			}
		}
	}
}