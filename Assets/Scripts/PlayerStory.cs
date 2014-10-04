using UnityEngine;
using System.Collections;

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


	void Start(){
		playerDead = false;
		soundPlayer = FindObjectOfType(typeof(SoundPlayer)) as SoundPlayer;
		DontDestroyOnLoad (soundPlayer);
	}
	
	// Update is called once per frame
	void Update () {

		// When left arrow key is held down, apply force going left.
		if (Input.GetKey ("left")) {
			if (isGrounded) {
				rigidbody2D.velocity = Vector2.zero;
				rigidbody2D.AddForce (leftForce);
			}
		}

		// When left or right arrow key is released and Swiper is grounded, stop horizontal movement.
		if (Input.GetKeyUp("left") || Input.GetKeyUp("right")) {
			if (isGrounded) {
				rigidbody2D.velocity = Vector2.zero;
			}
		}

		// When right arrow key is held down, apply force going right.
		if (Input.GetKey("right")) {
			if (isGrounded) {
				rigidbody2D.velocity = Vector2.zero;
				rigidbody2D.AddForce(rightForce);
			}
		}

		// When up arrow key is pressed AND the character is grounded, apply force going up.
		if (Input.GetKeyDown("up") && isGrounded == true) {
			soundPlayer.PlaySoundEffect ("bounce");
			rigidbody2D.AddForce(jumpForce);
			isGrounded = false;
		}

		previousVelocity = rigidbody2D.velocity;
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

		// If collision is with an enemy object, decrease the relevant count.
		// Don't forget to change this for bouncing behaviour.
		if (other.transform.gameObject.tag == "Enemy") {
			soundPlayer.PlaySoundEffect ("hit");
			health--;

			if(health < max_health) {
				// Get reference to list of all Life objects.
				Life[] lives = FindObjectsOfType(typeof(Life)) as Life[];
				// Make all Life objects transparent.
				foreach (Life life in lives) {
					life.MakeOpaque();
				}
			}

			if (health==0){
				Die ();
			}
			rigidbody2D.velocity = previousVelocity;
		}
		
		// If collision is with the ground or platform, mark player as "grounded".
		if(other.transform.gameObject.tag == "Floor" || other.transform.gameObject.tag == "Ground" || other.transform.gameObject.tag == "Platform") {
			isGrounded = true;
		}
	}

	void Die(){
		collider2D.enabled = false;
		rigidbody2D.AddForce(deathForce);
		soundPlayer.Death ();
		playerDead = true;
	}
}
