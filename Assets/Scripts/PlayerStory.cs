using UnityEngine;
using System.Collections;

// Class for the player object
public class PlayerStory : MonoBehaviour {

	// Vectors for movement.
	public Vector2 jumpForce; 
	public Vector2 deathForce;
	public Vector2 leftForce;
	public Vector2 rightForce;
	private Vector2 previousVelocity; // Store this so that collisions with coins do not cause Swiper to bounce.
	
	public int coins; // Integer to store number of coins collected.
	public int health; // Integer to store remaining health.
	public int max_health;
	private bool isGrounded = true; // Boolean to store whether player is grounded (i.e. on the ground or platform, as opposed to in mid air).

	private Life[] lives;
	private SoundPlayer soundPlayer;

	public bool playerDead;
	public bool levelFinished;
	private PauseMenu pauseMenu;

	// These are the dimensions that we have scaled the sprite by. Don't change these! We need to reference these numbers to do the horizontal flip.
	private float xDimension = 0.5166001f;
	private float yDimension = 0.5165996f;

	// Animator when for Hero running animation.
	Animator anim;

	// Initialise sound player and pause menu.
	void Start(){

		// Animator when we have for Hero running animation.
		anim = GetComponent<Animator> ();

		pauseMenu = FindObjectOfType(typeof(PauseMenu)) as PauseMenu;

		playerDead = false;
		levelFinished = false;
		soundPlayer = FindObjectOfType(typeof(SoundPlayer)) as SoundPlayer;
		DontDestroyOnLoad (soundPlayer);
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		// If the game is not paused, then:
		if (pauseMenu.isPaused == false) {
						// If Swiper is below the screen, kill him.
						Vector2 screenPosition = Camera.main.WorldToScreenPoint (transform.position);
						if (screenPosition.y < 0) {
								health = 0;
								Die ();
						}

						// If Swiper's health is zero, run the death routine.
						if (health < 1) {
								Die ();
						}

						// When left arrow key is held down, apply force going left.
						if (Input.GetKey ("left")) {
								if (isGrounded) {
								rigidbody2D.velocity = Vector2.zero;
								rigidbody2D.AddForce (leftForce);
								transform.localScale = new Vector2(-xDimension , yDimension); // Flip sprite horizontally
							}
						}

						// When left or right arrow key is released and Swiper is grounded, stop horizontal movement.
						if (Input.GetKeyUp ("left") || Input.GetKeyUp ("right")) {
								if (isGrounded) {
										rigidbody2D.velocity = Vector2.zero;
								}
						}

						// When right arrow key is held down, apply force going right.
						if (Input.GetKey ("right")) {
							if (isGrounded) {
								rigidbody2D.velocity = Vector2.zero;
								rigidbody2D.AddForce (rightForce);
								transform.localScale = new Vector2(xDimension , yDimension); // Flip sprite horizontally
							}
						}

						// When up arrow key is pressed AND the character is grounded, apply force going up.
						if (Input.GetMouseButtonDown(0) && isGrounded == true) {
								soundPlayer.PlaySoundEffect ("bounce");
								rigidbody2D.AddForce (jumpForce);
								isGrounded = false;
						}

						previousVelocity = rigidbody2D.velocity;

						var x_accel = (float)Input.acceleration.x;
						x_accel = (float)0.4 * x_accel;
						
						// Upper limits
						if (x_accel > (float)0.15) {
							x_accel = (float)0.15;
						} else if (x_accel < (float)-0.15) {
							x_accel = (float)-0.15;
						}
						
						// Lower limits
						if (x_accel < (float)0.05 && x_accel > (float)-0.05) {
							x_accel = 0;
						}
						
						// Un-comment animator when we have a better running animation.
						anim.SetFloat ("Speed", Mathf.Abs (x_accel));
						
						//Read accelerometer input in the x direction
						transform.Translate (x_accel, 0, 0);

						// Flip sprite horizontally depending on acceleration.
						if(x_accel < 0) {
							transform.localScale = new Vector2(-xDimension , yDimension); // Make sprite face left
						} else if(x_accel > 0) {
							transform.localScale = new Vector2(xDimension , yDimension); // Make sprite face right
						}

						previousVelocity = rigidbody2D.velocity;
				}
	}

	// Detects collision with anything.
	void OnCollisionEnter2D(Collision2D other) {

		// If collision is with a coin object, increase the relevant count.
		if (other.transform.gameObject.tag == "Coin") {
			coins++;
			Destroy (other.gameObject);
			soundPlayer.PlaySoundEffect("cash register");
			rigidbody2D.velocity = previousVelocity;
		}

		// If collision is with a life object, increase the relevant count.
		if (other.transform.gameObject.tag == "Life") {
			if(health < max_health) {
				health++;
				soundPlayer.PlaySoundEffect ("health");
				Destroy(other.gameObject);
				if(health == max_health) {
					// Get reference to list of all Life objects.
					Life[] lives = FindObjectsOfType(typeof(Life)) as Life[];
					// Make all Life objects transparent.
					foreach (Life life in lives) {
						life.MakeTransparent();
					}
				}
			}
			rigidbody2D.velocity = previousVelocity;
		}

		// If collision is with an enemy object...
		if (other.transform.gameObject.tag == "Enemy") {

			if(transform.position.y-0.6f >= other.transform.position.y+0.36){ // If the player has bounced on the top of the enemy, then:
				// Do nothing? Play a sound?

			} else { // If the player has collided into the enemy in the regular way, then decrease the relevant count. Update the life packs to make them opaque again.
				soundPlayer.PlaySoundEffect ("hit");
				health--;
				RedFlash flash = FindObjectOfType(typeof(RedFlash)) as RedFlash;
				StartCoroutine(flash.FlashOnHit());

				if(health < max_health) {
					// Get reference to list of all Life objects.
					Life[] lives = FindObjectsOfType(typeof(Life)) as Life[];
					// Make all Life objects transparent.
					foreach (Life life in lives) {
						life.MakeOpaque();
					}
				}
			}
			rigidbody2D.velocity = previousVelocity;
		}
		
		// If collision is with the ground or platform, mark player as "grounded".
		if(other.transform.gameObject.tag == "Floor" || other.transform.gameObject.tag == "Ground" || other.transform.gameObject.tag == "Platform") {
			isGrounded = true;
		}

		if (other.transform.gameObject.tag == "endFlag") {
			levelFinished = true;
			soundPlayer.PlaySoundEffect("applause");
		}
	}

	// Function to kill swiper. Plays death sounds and animation.
	void Die(){
		if (playerDead == false) {
			collider2D.enabled = false;
			rigidbody2D.AddForce (deathForce);
			soundPlayer.Death ();
			playerDead = true;
		}
	}
}
