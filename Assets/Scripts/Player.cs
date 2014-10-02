using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// Vectors for movement.
	public Vector2 upForce = new Vector2 (0,500); 
	public Vector2 leftForce = new Vector2(-500,0);
	public Vector2 rightForce = new Vector2(500,0);

	int coins = 0; // Integer to store number of coins collected.
	bool isGrounded = true; // Boolean to store whether player is grounded (i.e. on the ground or platform, as opposed to in mid air).

	// Display number of collisions.
	void OnGUI () 
	{
		GUI.color = Color.black;
		GUILayout.Label(" COINS: " + coins.ToString());
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

		// When left arrow key is released, stop horizontal movement.
		if (Input.GetKeyUp("left")){
			rigidbody2D.velocity = Vector2.zero;
		}

		// When right arrow key is held down, apply force going right.
		if (Input.GetKey("right"))
		{
			if (isGrounded) {
				rigidbody2D.velocity = Vector2.zero;
				rigidbody2D.AddForce(rightForce);
			}
		}

		// When right arrow key is released, stop horizontal movement.
		if (Input.GetKeyUp("right")){
			rigidbody2D.velocity = Vector2.zero;
		}

		// When up arrow key is pressed AND the character is grounded, apply force going up.
		if (Input.GetKeyDown("up") && isGrounded == true)
		{
			rigidbody2D.velocity = Vector2.zero;
			rigidbody2D.AddForce(upForce);
			isGrounded = false;
		}
	}

	// Detects collision with anything.
	void OnCollisionEnter2D(Collision2D other)
	{
		// If collision is with object "peso" or one of its clones, increase the count.
		if (other.transform.gameObject.name == "peso" || other.transform.gameObject.name == "peso(Clone)") {
			coins++;
		}

		// If collision is with the ground or platform, mark player as "grounded".
		if(other.transform.gameObject.tag == "Floor" || other.transform.gameObject.tag == "Ground" || other.transform.gameObject.tag == "Platform") {
			isGrounded = true;
		}
	}
}
