using UnityEngine;
using System.Collections;

public class GroundCollisionEndless : MonoBehaviour {
	private PlayerEndless player;

	void Start () {
		player = FindObjectOfType(typeof (PlayerEndless)) as PlayerEndless;
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
