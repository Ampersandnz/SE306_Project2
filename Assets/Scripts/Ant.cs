using UnityEngine;
using System.Collections;

// Class for the ant enemy.
public class Ant : MonoBehaviour {

	public float leftLimit;
	public float rightLimit;
	public int direction; // Direction of movement. 1 is left and -1 is right.

	public bool alive;
	private SoundPlayer soundPlayer;
	Animator anim;

	void Start () {
		alive = true;
		anim = GetComponent<Animator> ();

		// Setting default values for the left and right limits.
		direction = 1;

		// Setting up sound player.
		soundPlayer = FindObjectOfType(typeof(SoundPlayer)) as SoundPlayer;
		DontDestroyOnLoad (soundPlayer);
	}

	void Update () {
		// If ant is dead, then:
		if (alive == false) {
			soundPlayer.PlaySoundEffect("crunch");
			anim.SetBool ("isAlive", false); // Change to "dead ant" texture.
			collider2D.enabled = false; // Make ant intangible so Swiper can't collide with the carcass.
		} else {

			// Moving left and right
			if (transform.position.x > rightLimit) {
				direction = 1;
				transform.localScale = new Vector2(0.3f , 0.3f); // Flip sprite horizontally
			} else if (transform.position.x < leftLimit) {
				direction = -1;
				transform.localScale = new Vector2(-0.3f , 0.3f); // Flip sprite horizontally
			}
			transform.position = new Vector2 (transform.position.x + (-0.02f * (float)direction), transform.position.y);
		}
	}
}
