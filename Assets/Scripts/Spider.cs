using UnityEngine;
using System.Collections;

// Class for the ant enemy.
public class Spider : MonoBehaviour {
	public GameObject coin;

	public bool alive;
	private SoundPlayer soundPlayer;
	
	void Start () {
		alive = true;
		
		// Setting up sound player.
		soundPlayer = FindObjectOfType(typeof(SoundPlayer)) as SoundPlayer;
		DontDestroyOnLoad (soundPlayer);
	}
	
	void Update () {
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

		// the position of ant's before it dead
		var positionX = transform.position.x;
		var positionY = transform.position.y;
		
		//generate a coin when the ant been killed.
		CreateObject (coin, positionX+1.2f, positionY+3.0f);

		soundPlayer.PlaySoundEffect ("crunch");
		Destroy (gameObject, 0.5f);
	}
}
