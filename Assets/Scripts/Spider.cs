using UnityEngine;
using System.Collections;

// Class for the ant enemy.
public class Spider : MonoBehaviour {
	
<<<<<<< HEAD
	private PlayerStory player;

	public GameObject Swiper;
	public GameObject coin;

=======
>>>>>>> feature/feet_stuff
	public bool alive;
	private SoundPlayer soundPlayer;
	
	void Start () {
		alive = true;
		
		// Setting up sound player.
		soundPlayer = FindObjectOfType(typeof(SoundPlayer)) as SoundPlayer;
		DontDestroyOnLoad (soundPlayer);
	}
	
	void Update () {
		// If spider is dead, then:
		if (alive == false) {
<<<<<<< HEAD
=======
			soundPlayer.PlaySoundEffect("crunch");
>>>>>>> feature/feet_stuff
			collider2D.enabled = false; // Make ant intangible so Swiper can't collide with the carcass.

			// the position of spider's before it dead
			var positionX = transform.position.x;
			var positionY = transform.position.y;
			
			Destroy (gameObject, 0.5f);
			
			//generate a coin when the ant been killed.
			CreateObject (coin, positionX+1.2f, positionY+3.0f);
			
			alive = true;

		} else {
			
			// Implement movement.
			
		}
	}
<<<<<<< HEAD
	
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

	/* Method to create an object. Paramaters:
	 * 	- obj - The GameObject to clone.
	 * 	- x - The absolute x ordinate of the object.
	 * 	- y - The absolute y ordinate of the object.
	*/
	public void CreateObject(GameObject obj, float x, float y){
		Instantiate (obj, new Vector2 (x, y), Quaternion.identity);
	}
=======
>>>>>>> feature/feet_stuff
}
