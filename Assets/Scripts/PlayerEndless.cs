using UnityEngine;
using System.Collections;

// Class for the player object
public class PlayerEndless : MonoBehaviour {
	
	// Vectors for movement.
	public Vector2 jumpForce; 
	public Vector2 deathForce;
	public Vector2 runForce;
	public Vector2 enemyBounce;
	private Vector2 previousVelocity; // Store this so that collisions with coins do not cause Swiper to bounce.
	
	public int coins; // Integer to store number of coins collected.
	public int health; // Integer to store remaining health.
	public int max_health;
	
	private Life[] lives;
	private SoundPlayer soundPlayer;
	
	public bool playerDead;
	public bool levelFinished;
	private PauseMenuEndless pauseMenu;

	private bool hitPlatform;
	private bool run;

	public bool isGrounded = true; // Boolean to store whether player is grounded (i.e. on the ground or platform, as opposed to in mid air).
		
	// Animator when for Hero running animation.
	Animator anim;
	
	// Initialise sound player and pause menu.
	void Start(){
		
		// Animator when we have for Hero running animation.
		anim = GetComponent<Animator> ();
		
		pauseMenu = FindObjectOfType(typeof(PauseMenuEndless)) as PauseMenuEndless;
		hitPlatform = false;
		playerDead = false;
		run = false;
		levelFinished = false;
		soundPlayer = FindObjectOfType(typeof(SoundPlayer)) as SoundPlayer;
		DontDestroyOnLoad (soundPlayer);
		anim.SetFloat ("Speed", Mathf.Abs (5));
		GetComponent<Rigidbody2D>().AddForce (jumpForce);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		previousVelocity = GetComponent<Rigidbody2D>().velocity;
		// If the game is not paused, then:
		if (pauseMenu.isPaused == false) {

			// Add the run force
			if (isGrounded) {
				run = true;
			}
			if (run){
				GetComponent<Rigidbody2D>().velocity = new Vector2(0f, previousVelocity.y);
				GetComponent<Rigidbody2D>().AddForce (runForce);
			}

			// When up arrow key is pressed AND the character is grounded, apply force going up.
			if ((Input.GetMouseButtonDown(0) || Input.GetKey ("up")) && isGrounded == true) {
				soundPlayer.PlaySoundEffect ("bounce");
				GetComponent<Rigidbody2D>().AddForce (jumpForce);
			}

		}
	}
	
	// Detects collision with anything.
	void OnCollisionEnter2D(Collision2D other) {
		
		// If collision is with a coin object, increase the relevant count.
		if (other.transform.gameObject.tag == "Coin") {
			coins++;
			Destroy (other.gameObject);
			soundPlayer.PlaySoundEffect("cash register");
			GetComponent<Rigidbody2D>().velocity = previousVelocity;
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
			GetComponent<Rigidbody2D>().velocity = previousVelocity;
		}
		
		// If collision is with an enemy object...
		if (other.transform.gameObject.tag == "Enemy") {		
			
			Ant ant = other.gameObject.GetComponent<Ant>();
			if (ant != null && ant.alive) {
				Die();
			}
			
			RedAnt redAnt = other.gameObject.GetComponent<RedAnt>();
			if (redAnt != null && redAnt.hitCount < 2) {
				Die();
			}
			
			Spider spider = other.gameObject.GetComponent<Spider>();
			if (spider != null && spider.alive) {
				Die();
			}
		}

		if ((other.transform.gameObject.tag == "Platform")||(other.transform.gameObject.tag =="Ground")) {
			sideHit();
		}
	}
	
	public void sideHit(){
		hitPlatform = true;
		run = false;
	}

	// Function to kill swiper. Plays death sounds and animation.
	public void Die() {
		if (playerDead == false) {
			GetComponent<Collider2D>().enabled = false;
			GetComponent<Rigidbody2D>().AddForce (deathForce);
			soundPlayer.Death();
			playerDead = true;
		}
	}
}