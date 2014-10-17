using UnityEngine;
using System.Collections;

public class EndFlag : MonoBehaviour {
	
	PlayerStory player;
	SoundPlayer soundPlayer;
	
	bool playedSound = false;
	
	// Use this for initialization
	void Start () {
		player = FindObjectOfType(typeof(PlayerStory)) as PlayerStory;
		soundPlayer = FindObjectOfType (typeof(SoundPlayer)) as SoundPlayer;
		DontDestroyOnLoad (soundPlayer);
	}
	
	// Update is called once per frame
	void Update () {
		
		// If Swiper has gone above or beyond the flag, mark the level as completed.
		if (player.transform.position.x >= transform.position.x) {
			endLevel();
		}
	}
	
	// If Swiper collides with the flag, mark level as completed.
	void OnCollisionEnter2D(Collision2D other) {
		if (other.transform.gameObject.tag == "Player") {
			endLevel ();
		}
	}
	
	void endLevel(){
		if(playedSound==false){
			soundPlayer.PlaySoundEffect("applause");
			playedSound = true;
		}
		player.levelFinished = true;
	}
}
