using UnityEngine;
using System.Collections;

public class GroundCollision : MonoBehaviour {
	private PlayerStory player;

	void Start () {
		player = FindObjectOfType(typeof (PlayerStory)) as PlayerStory;
	}

	void OnTriggerEnter2D (Collider2D other) {
		if(other.transform.gameObject.tag == "Floor" || other.transform.gameObject.tag == "Ground" || other.transform.gameObject.tag == "Platform") {
			player.isGrounded = true;
		}
	}
	
	void OnTriggerExit2D (Collider2D other) {
		if(other.transform.gameObject.tag == "Floor" || other.transform.gameObject.tag == "Ground" || other.transform.gameObject.tag == "Platform") {
			player.isGrounded = false;
		}
	}
}
