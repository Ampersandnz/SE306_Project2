using UnityEngine;
using System.Collections;

public class PlayerStory : MonoBehaviour {

	// Vectors for movement.
	public Vector2 jumpForce = new Vector2(0, 0); 
	public Vector2 leftForce = new Vector2(0, 0);
	public Vector2 rightForce = new Vector2(0, 0);
	private Vector2 previousVelocity; // Store this so that collisions with coins do not cause Swiper to bounce.
	
	public int coins = 0; // Integer to store number of coins collected.
	public int health = 3; // Integer to store remaining health.
	private bool isGrounded = true; // Boolean to store whether player is grounded (i.e. on the ground or platform, as opposed to in mid air).
	
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
			rigidbody2D.AddForce(jumpForce);
			isGrounded = false;
		}

		previousVelocity = rigidbody2D.velocity;
	}

	// Detects collision with anything.
	void OnCollisionEnter2D(Collision2D other) {
		// If collision is with object "peso" or one of its clones, increase the count.
		if (other.transform.gameObject.tag == "Coin") {
			coins++;
			rigidbody2D.velocity = previousVelocity;
		}

		if (other.transform.gameObject.tag == "Enemy") {
			return;
		}

		// If collision is with the ground or platform, mark player as "grounded".
		if(other.transform.gameObject.tag == "Floor" || other.transform.gameObject.tag == "Ground" || other.transform.gameObject.tag == "Platform") {
			isGrounded = true;
		}
	}
}
