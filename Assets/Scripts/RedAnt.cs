using UnityEngine;
using System.Collections;

public class RedAnt : MonoBehaviour {
	private PlayerStory player;
	public float leftLimit;
	public float rightLimit;
	public int direction; // Direction of movement. 1 is left and -1 is right.
	
	public bool alive;
	private SoundPlayer soundPlayer;
	Animator anim;
	
	void Start () {
		alive = true;
		anim = GetComponent<Animator> ();
		
		// Getting reference to player object.
		player = FindObjectOfType(typeof(PlayerStory)) as PlayerStory;
		
		// Setting default values for the left and right limits.
		leftLimit = -1;
		rightLimit = 1;
		direction = 1;
		
		// Setting up sound player.
		soundPlayer = FindObjectOfType(typeof(SoundPlayer)) as SoundPlayer;
		DontDestroyOnLoad (soundPlayer);
	}
	
	void Update () {
		// If ant is dead, then:
		if (alive == false) {
			anim.SetBool ("hit1", true); // Change to "dead ant" texture.

			//transform.localScale = new Vector2(0.3f , 0.3f);
			if (transform.position.x > rightLimit) {
				direction = 1;
				transform.localScale = new Vector2(0.3f , 0.3f); // Flip sprite horizontally
			} else if (transform.position.x < leftLimit) {
				direction = -1;
				transform.localScale = new Vector2(-0.3f , 0.3f); // Flip sprite horizontally
			}
			transform.position = new Vector2 (transform.position.x + (-0.02f * (float)direction), transform.position.y);
			collider2D.enabled = false; // Make ant intangible so Swiper can't collide with the carcass.
		} else {
			
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
			if (player.transform.position.y - 0.6f >= transform.position.y + 0.7) {
				alive = false;
				soundPlayer.PlaySoundEffect("crunch");
			}
		}
	}
}
