﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public Vector2 upForce = new Vector2 (0,400);
	public Vector2 leftForce = new Vector2(-200,0);
	public Vector2 rightForce = new Vector2(200,0);
	int coins = 0;
	bool isGrounded = true;

	// Display number of collisions.
	void OnGUI () 
	{
		GUI.color = Color.black;
		GUILayout.Label(" COINS: " + coins.ToString());
	}
	
	// Update is called once per frame
	void Update () {
		// Move horizontally
		if (Input.GetKey ("left")) {
			if (isGrounded) {
				rigidbody2D.velocity = Vector2.zero;
				rigidbody2D.AddForce (leftForce);
			}
		}

		if (Input.GetKey("right"))
		{
			if (isGrounded) {
				rigidbody2D.velocity = Vector2.zero;
				rigidbody2D.AddForce(rightForce);
			}
		}

		// Move vertically
		if (Input.GetKeyDown("up") && rigidbody2D.velocity.y==0)
		{
			//rigidbody2D.velocity = Vector2.zero;
			rigidbody2D.AddForce(upForce);
			//rigidbody2D.AddForce (new Vector2(0,400));
			isGrounded = false;
		}
	}

	// Collide with anything.
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.transform.gameObject.tag == "Coin") {
			coins++;
		}

		if(other.transform.gameObject.tag == "Floor" || other.transform.gameObject.tag == "Ground" || other.transform.gameObject.tag == "Platform") {
			isGrounded = true;
		}
	}
}
