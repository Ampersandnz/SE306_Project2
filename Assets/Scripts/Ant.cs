using UnityEngine;
using System.Collections;

// Class for the ant enemy.
public class Ant : MonoBehaviour {
	
	private PlayerStory player;
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
		
		// Getting reference to player object.
		player = FindObjectOfType(typeof(PlayerStory)) as PlayerStory;
		
		// Setting default values for the left and right limits.
		direction = 1;
		
		// Setting up sound player.
		soundPlayer = FindObjectOfType(typeof(SoundPlayer)) as SoundPlayer;
		DontDestroyOnLoad (soundPlayer);
	}
	
	void Update () {
		// If ant is dead, then:
		if (alive == false) {

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
			
		}
	}
	
	void OnCollisionEnter2D(Collision2D other) {
		
		// If collision is with Swiper, check if it is dead.
		if (other.transform.gameObject.name == "Swiper") {

			// the position of swiper when the hit detect
			var Sx = Swiper.transform.position.x;
			var Sy = Swiper.transform.position.y;


			if (player.transform.position.y - 0.6f >= transform.position.y + 0.7f) {
				alive = false;
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
}
