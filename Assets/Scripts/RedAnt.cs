using UnityEngine;
using System.Collections;

public class RedAnt : MonoBehaviour {
	private PlayerStory player;
	public float leftLimit;
	public float rightLimit;
	public int direction; // Direction of movement. 1 is left and -1 is right.

	public GameObject coin;
	public GameObject Swiper;

	//public bool alive;
	public bool Hit1 = false;
	public bool Hit2 = false;
	public int hitCount;
	private SoundPlayer soundPlayer;
	Animator anim;
	
	void Start () {
		//alive = true;
		anim = GetComponent<Animator> ();

		// Getting reference to player object.
		player = FindObjectOfType(typeof(PlayerStory)) as PlayerStory;
		
		// Setting default values for the left and right limits.
		//leftLimit = -1;
		//rightLimit = 1;
		direction = 1;
		
		// Setting up sound player.
		soundPlayer = FindObjectOfType(typeof(SoundPlayer)) as SoundPlayer;
		DontDestroyOnLoad (soundPlayer);
	}
	
	void Update () {
		// If red ant lose one live, then:
		if (Hit1 == true) {
			anim.SetBool ("hit1", true); // Change to "dead ant" texture.

			if (transform.position.x > rightLimit) {
				direction = 1;
				transform.localScale = new Vector2(0.6f , 0.6f); // Flip sprite horizontally
			} else if (transform.position.x < leftLimit) {
				direction = -1;
				transform.localScale = new Vector2(-0.6f , 0.6f); // Flip sprite horizontally
			}
			transform.position = new Vector2 (transform.position.x + (-0.02f * (float)direction), transform.position.y);
			//collider2D.enabled = false; // Make ant intangible so Swiper can't collide with the carcass.
		} 

		// if ant dead
		else if(Hit2 == true){
			collider2D.enabled = false; // Make ant intangible so Swiper can't collide with the carcass.
			anim.SetBool ("hit2", true); // Change to "dead ant" texture.
			//collider2D.enabled = false;

			// the position of ant's before it dead
			var positionX = transform.position.x;
			var positionY = transform.position.y;

			Destroy (gameObject, 0.5f);

			//generate a coin when the ant been killed.
			CreateObject (coin, positionX+1.2f, positionY+3.0f);

			Hit2 = false;
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
		
		// If collision is with Swiper, check if it loss life or dead.
		if (other.transform.gameObject.name == "Swiper") {

			//the lowest position of swiper's collider box
			var colliderSwiper = Swiper.GetComponent<BoxCollider2D>();
			var colliderS = colliderSwiper.collider2D;

			// the highest position of redAnt's collider
			var colliderRedAnt = GetComponent<BoxCollider2D>();
			var colliderRA = colliderRedAnt.collider2D;

			//if detect collison from top
			if (colliderS.bounds.min.y >= colliderRA.bounds.max.y){
				Hit1 = false;
				Hit2 = false;
				hitCount++;

				// the position of swiper when the hit detect
				var Sx = Swiper.transform.position.x;
				var Sy = Swiper.transform.position.y;

				// the first time hit by swiper - loss one life change to black ant
				if(hitCount == 1){
					Hit1 = true;
					Swiper.transform.position = new Vector2(Sx, Sy+3.0f);
				}

				//the second time hit by swiper - dead
				if (hitCount == 2){
					Hit2 = true;
					hitCount = 0;
					soundPlayer.PlaySoundEffect("crunch");
					Swiper.transform.position = new Vector2(Sx, Sy+3.0f);
				}

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
