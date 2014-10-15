using UnityEngine;
using System.Collections;

// Class for the ant enemy.
public class Spider : MonoBehaviour {
	
	private PlayerStory player;
	
	public bool alive;
	private SoundPlayer soundPlayer;
	
	void Start () {
		alive = true;
		
		// Getting reference to player object.
		player = FindObjectOfType(typeof(PlayerStory)) as PlayerStory;
		
		// Setting up sound player.
		soundPlayer = FindObjectOfType(typeof(SoundPlayer)) as SoundPlayer;
		DontDestroyOnLoad (soundPlayer);
	}
	
	void Update () {
		// If spider is dead, then:
		if (alive == false) {
			collider2D.enabled = false; // Make ant intangible so Swiper can't collide with the carcass.
		} else {
			
			// Implement movement.
			
		}
	}
	
	void OnCollisionEnter2D(Collision2D other) {
		
		// If collision is with Swiper, check if it is dead.

		if (other.transform.gameObject.name == "Swiper") {
			if (player.transform.position.y - 0.6f >= transform.position.y + 0.5) {
				alive = false;
				Destroy(gameObject);
				soundPlayer.PlaySoundEffect("crunch");
			}
		}
	}
}
