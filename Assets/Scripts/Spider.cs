using UnityEngine;
using System.Collections;

// Class for the ant enemy.
public class Spider : MonoBehaviour {
	
	private PlayerStory player;


	public GameObject coin;
	public GameObject Swiper;

	public bool alive;
	private SoundPlayer soundPlayer;
	
	void Start () {
		alive = true;
		
		// Getting reference to player object.
		player = FindObjectOfType(typeof(PlayerStory)) as PlayerStory;
		
		// Setting up sound player.
		soundPlayer = FindObjectOfType(typeof(SoundPlayer)) as SoundPlayer;
		DontDestroyOnLoad (soundPlayer);
	}
	
	void Update () {
		// If spider is dead, then:
		if (alive == false) {
			collider2D.enabled = false; // Make ant intangible so Swiper can't collide with the carcass.

			// the position of ant's before it dead
			var positionX = transform.position.x;
			var positionY = transform.position.y;
			
			//generate a coin when the ant been killed.
			CreateObject (coin, positionX+1.2f, positionY+3.0f);
			
			Destroy (gameObject, 0.5f);
			
			alive = true;

		} else {
			
			// Implement movement.
			
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
}
