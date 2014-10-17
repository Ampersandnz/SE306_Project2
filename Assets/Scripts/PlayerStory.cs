﻿using UnityEngine;
using System.Collections;

// Class for the player object
public class PlayerStory : MonoBehaviour {

	// Vectors for movement.
	public Vector2 jumpForce; 
	public Vector2 deathForce;
	public Vector2 leftForce;
	public Vector2 rightForce;
	private Vector2 enemyBounceLeft;
	private Vector2 enemyBounceRight;
	private Vector2 enemyBounceUp;
	private Vector2 previousVelocity; // Store this so that collisions with coins do not cause Swiper to bounce.
	
	public int coins; // Integer to store number of coins collected.
	public int health; // Integer to store remaining health.
	public int max_health;

	private Life[] lives;
	private SoundPlayer soundPlayer;

	public GameObject Spider;
	public bool playerDead;
	public bool levelFinished;
	private PauseMenu pauseMenu;

	private bool invulnerable = false;
	public bool isGrounded = true; // Boolean to store whether player is grounded (i.e. on the ground or platform, as opposed to in mid air).

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
		previousVelocity = rigidbody2D.velocity;

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
				rigidbody2D.velocity = new Vector2(0f, previousVelocity.y);
				Vector2 force;
				if (isGrounded) {
					force = (leftForce);
				} else {
					force = leftForce;
				}
				rigidbody2D.AddForce (force);
				transform.localScale = new Vector2(-xDimension, yDimension); // Flip sprite horizontally
			}

			// When left or right arrow key is released and Swiper is grounded, stop horizontal movement.
			if (Input.GetKeyUp ("left") || Input.GetKeyUp ("right")) {
				if (isGrounded) {
					rigidbody2D.velocity = Vector2.zero;
				}
			}

			// When right arrow key is held down, apply force going right.
			if (Input.GetKey ("right")) {
				rigidbody2D.velocity = new Vector2(0f, previousVelocity.y);
				Vector2 force;
				if (isGrounded) {
					force = (rightForce);
				} else {
					force = rightForce;
				}
				rigidbody2D.AddForce (force);
				transform.localScale = new Vector2(xDimension, yDimension); // Flip sprite horizontally
			}

			// When up arrow key is pressed AND the character is grounded, apply force going up.
			if ((Input.GetMouseButtonDown(0) || Input.GetKey ("up")) && isGrounded == true) {
				soundPlayer.PlaySoundEffect ("bounce");
				rigidbody2D.AddForce (jumpForce);
			}
		
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
			if(x_accel < 0){
				transform.localScale = new Vector2(-xDimension , yDimension); // Make sprite face left
			}else if(x_accel > 0){
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

			if(transform.position.y-0.6f >= other.transform.position.y+0.7){ // If the player has bounced on the top of the enemy, then:
				// Do nothing? Play a sound?

			} else { // If the player has collided into the enemy in the regular way, then decrease the relevant count. Update the life packs to make them opaque again.
				if (! invulnerable) {
					if(health == max_health) {
						// Get reference to list of all Life objects.
						Life[] lives = FindObjectsOfType(typeof(Life)) as Life[];
						// Make all Life objects transparent.
						foreach (Life life in lives) {
							life.MakeOpaque();
						}
					}

					RedFlash flash = FindObjectOfType(typeof(RedFlash)) as RedFlash;
					StartCoroutine(flash.FlashOnHit());
					StartCoroutine(becomeInvulnerable());
					soundPlayer.PlaySoundEffect ("hit");
					health--;
				}
			}

			// Later we'll detect which direction Swiper hit the enemy from (left, right, or above), and bounce him off a little bit in the opposite direction.
			Vector2 enemyBounceForce = new Vector2(0f,0f);
			rigidbody2D.velocity = previousVelocity;
			rigidbody2D.AddForce(enemyBounceForce);
		}
<<<<<<< HEAD
=======

		// If collision is with a Spider object...
		if (other.transform.gameObject.tag == "Spider") {
			
			/*if(transform.position.y-0.6f >= other.transform.position.y+0.7){ // If the player has bounced on the top of the enemy, then:
				// Do nothing? Play a sound?
				
			}*/

			var colliderSwiper = GetComponent<BoxCollider2D>();
			var colliderSw = colliderSwiper.collider2D;
			
			// the highest position of Ant's collider
			var colliderSpider = GetComponent<BoxCollider2D>();
			var colliderSp = colliderSpider.collider2D;

			if(colliderSw.bounds.min.y >= colliderSp.bounds.max.y){

			}

			else { // If the player has collided into the enemy in the regular way, then decrease the relevant count. Update the life packs to make them opaque again.
				if (! invulnerable) {
					if(health == max_health) {
						// Get reference to list of all Life objects.
						Life[] lives = FindObjectsOfType(typeof(Life)) as Life[];
						// Make all Life objects transparent.
						foreach (Life life in lives) {
							life.MakeOpaque();
						}
					}
					
					RedFlash flash = FindObjectOfType(typeof(RedFlash)) as RedFlash;
					StartCoroutine(flash.FlashOnHit());
					StartCoroutine(becomeInvulnerable());
					soundPlayer.PlaySoundEffect ("hit");
					health--;
				}
			}
			
			// Later we'll detect which direction Swiper hit the enemy from (left, right, or above), and bounce him off a little bit in the opposite direction.
			Vector2 enemyBounceForce = new Vector2(0f,0f);
			rigidbody2D.velocity = previousVelocity;
			rigidbody2D.AddForce(enemyBounceForce);
		}
		// If collision is with the ground or platform, mark player as "grounded".
		if(other.transform.gameObject.tag == "Floor" || other.transform.gameObject.tag == "Ground" || other.transform.gameObject.tag == "Platform") {
			isGrounded = true;
		}
>>>>>>> feature/level2

		// If Swiper has reached the end flag, mark the level as completed.
		if (other.transform.gameObject.tag == "endFlag") {
			levelFinished = true;
			soundPlayer.PlaySoundEffect("applause");
		}
	}

	// Function to kill swiper. Plays death sounds and animation.
	void Die() {
		if (playerDead == false) {
			collider2D.enabled = false;
			rigidbody2D.AddForce (deathForce);
			soundPlayer.Death();
			playerDead = true;
		}
	}

	private IEnumerator becomeInvulnerable() {
		invulnerable = true;
		Color normal = renderer.material.color;
		Color flash = renderer.material.color;
		flash.a = 0;
		
		// Flash for 3 seconds
		for (int i = 0; i < 11; i++) {
			if (i % 2 == 0) {
				// Make the sprite invisible
				renderer.material.color = flash;
			} else {
				// Make it normal again
				renderer.material.color = normal;
			}
			yield return new WaitForSeconds (0.3f);
		}
		
		renderer.material.color = normal;
		invulnerable = false;
	}
}
