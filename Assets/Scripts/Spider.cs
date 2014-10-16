using UnityEngine;
using System.Collections;

// Class for the ant enemy.
public class Spider : MonoBehaviour {
	
	private PlayerStory player;

	public GameObject Swiper;

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
			Destroy(gameObject, 0.5f);
		} else {
			
			// Implement movement.
			
		}
	}
	
	void OnCollisionEnter2D(Collision2D other) {
		
		// If collision is with Swiper, check if it is dead.

		if (other.transform.gameObject.name == "Swiper") {

			//the lowest position of swiper's collider box
			var colliderSwiper = Swiper.GetComponent<BoxCollider2D>();
			var colliderSw = colliderSwiper.collider2D;
			
			// the highest position of Ant's collider
			var colliderSpider = GetComponent<BoxCollider2D>();
			var colliderSp = colliderSpider.collider2D;

			/*if (player.transform.position.y - 0.6f >= transform.position.y + 0.5) {
				alive = false;
				Destroy(gameObject);
				soundPlayer.PlaySoundEffect("crunch");
			}*/

			if (colliderSw.bounds.min.y >= colliderSp.bounds.max.y) {
				alive = false;
				//Destroy(gameObject, 0.5f);
				soundPlayer.PlaySoundEffect("crunch");
			}
		}
	}
}
