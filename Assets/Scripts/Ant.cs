using UnityEngine;
using System.Collections;

// Class for the ant enemy.
public class Ant : MonoBehaviour {

	private PlayerStory player;
	public float leftLimit;
	public float rightLimit;
	public int direction; // Direction of movement. 1 is left and -1 is right.

	public bool alive;
	private SoundPlayer soundPlayer;
	public PauseMenu pauseMenu;
	Animator anim;
	
	public PlayerStory Swiper;
	public GameObject coin;

	void Start () {
		alive = true;
		anim = GetComponent<Animator> ();

		// Getting reference to player object.
		Swiper = FindObjectOfType(typeof(PlayerStory)) as PlayerStory;

		// Getting reference to pause menu.
		pauseMenu = FindObjectOfType (typeof(PauseMenu)) as PauseMenu;
		
		// Setting default values for the left and right limits.
		direction = 1;

		// Setting up sound player.
		soundPlayer = FindObjectOfType(typeof(SoundPlayer)) as SoundPlayer;
		DontDestroyOnLoad (soundPlayer);
	}

	void Update () {
		if(!pauseMenu.isPaused) { // Disable movement while the game is paused.
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
	
	/* Method to create an object. Paramaters:
	 * 	- obj - The GameObject to clone.
	 * 	- x - The absolute x ordinate of the object.
	 * 	- y - The absolute y ordinate of the object.
	*/
	public void CreateObject(GameObject obj, float x, float y){
		Instantiate (obj, new Vector2 (x, y), Quaternion.identity);
	}

	public void Die() {
		alive = false;
		anim.SetBool ("isAlive", false); // Change to "dead ant" texture.
		
		// the position of ant's before it dead
		var positionX = transform.position.x;
		var positionY = transform.position.y;
		
		//generate a coin when the ant been killed.
		CreateObject (coin, positionX+1.2f, positionY+3.0f);

		Destroy (gameObject, 0.5f);
	}
}
