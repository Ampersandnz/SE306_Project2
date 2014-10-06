using UnityEngine;
using System.Collections;

// Class for the banana projectiles.
public class Banana : MonoBehaviour{
	public string behaviour;
	private Vector2 sideForce;
	
	void Start(){
		// Initialise position values.
		float Bootsx = transform.position.x;
		PlayerStory player = FindObjectOfType(typeof(PlayerStory)) as PlayerStory;
		float Swiperx = player.transform.position.x;
		float difference = Bootsx - Swiperx;

		// Customise behaviour based on the string.
		if(behaviour == "random"){
			sideForce = new Vector2(-250 + Random.value*500, 0);
			rigidbody2D.AddForce(sideForce);
		}else if(behaviour == "honing"){
			sideForce = new Vector2(-difference*42, 0);
			rigidbody2D.AddForce(sideForce);
		}
		// If no behaviour is chosen, the banana just drops straight down.
	}

	// If the banana hits something, destroy the banana.
	void OnCollisionEnter2D(Collision2D other) {
		Destroy(gameObject);
	}
}