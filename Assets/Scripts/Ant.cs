using UnityEngine;
using System.Collections;

// Class for the ant enemy.
public class Ant : MonoBehaviour {
<<<<<<< HEAD

=======
	
	private PlayerStory player;
>>>>>>> feature/ants
	public float leftLimit;
	public float rightLimit;
	public int direction; // Direction of movement. 1 is left and -1 is right.
	
	public bool alive;
	private SoundPlayer soundPlayer;
	Animator anim;

	public GameObject Swiper;
	public GameObject coin;
	
	void Start () {
		alive = true;
		anim = GetComponent<Animator> ();
<<<<<<< HEAD

=======
		
		// Getting reference to player object.
		player = FindObjectOfType(typeof(PlayerStory)) as PlayerStory;
		
>>>>>>> feature/ants
		// Setting default values for the left and right limits.
		direction = 1;
		
		// Setting up sound player.
		soundPlayer = FindObjectOfType(typeof(SoundPlayer)) as SoundPlayer;
		DontDestroyOnLoad (soundPlayer);
	}
	
	void Update () {
		// If ant is dead, then:
		if (alive == false) {
<<<<<<< HEAD
			soundPlayer.PlaySoundEffect("crunch");
			anim.SetBool ("isAlive", false); // Change to "dead ant" texture.
=======

>>>>>>> feature/ants
			collider2D.enabled = false; // Make ant intangible so Swiper can't collide with the carcass.

			anim.SetBool ("isAlive", false); // Change to "dead ant" texture.

			// the position of ant's before it dead
			var positionX = transform.position.x;
			var positionY = transform.position.y;
			
			Destroy (gameObject, 0.5f);
			
			//generate a coin when the ant been killed.
			CreateObject (coin, positionX+1.2f, positionY+3.0f);

			alive = true;

		} 

		else {
			
			// Moving left and right
			if (transform.position.x > rightLimit) {
				direction = 1;
				transform.localScale = new Vector2(0.6f , 0.6f); // Flip sprite horizontally
			} else if (transform.position.x < leftLimit) {
				direction = -1;
				transform.localScale = new Vector2(-0.6f , 0.6f); // Flip sprite horizontally
			}
			transform.position = new Vector2 (transform.position.x + (-0.02f * (float)direction), transform.position.y);
<<<<<<< HEAD
=======
			
		}
	}
	
	void OnCollisionEnter2D(Collision2D other) {
		
		// If collision is with Swiper, check if it is dead.
		if (other.transform.gameObject.name == "Swiper") {

			// the position of swiper when the hit detect
			var Sx = Swiper.transform.position.x;
			var Sy = Swiper.transform.position.y;

			//the lowest position of swiper's collider box
			var colliderSwiper = Swiper.GetComponent<BoxCollider2D>();
			var colliderS = colliderSwiper.collider2D;
			
			// the highest position of Ant's collider
			var colliderAnt = GetComponent<BoxCollider2D>();
			var colliderA = colliderAnt.collider2D;


			if (colliderS.bounds.min.y >= colliderA.bounds.max.y) {
				alive = false;
				soundPlayer.PlaySoundEffect("crunch");
				Swiper.transform.position = new Vector2(Sx, Sy+3.0f);
			}
>>>>>>> feature/ants
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
}
