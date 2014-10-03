using UnityEngine;
using System.Collections;

public class Life : MonoBehaviour {

	private PlayerStory player;

	void Start(){	
		player = (PlayerStory)FindObjectOfType (typeof(PlayerStory));
	}

	// If the player is at maximum health, make the health pack disappear.
	void Update(){
		if(player.health>=player.max_health){
			Destroy (gameObject);
		}
	}

	// Detect all collisions
	void OnCollisionEnter2D(Collision2D other) {
		if (other.transform.gameObject.name == "Swiper") {
			if( player.health < player.max_health){
				Destroy (gameObject); // If collision is with Swiper, destroy the life immediately.
			}
		}
	}
}