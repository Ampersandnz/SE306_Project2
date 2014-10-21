using UnityEngine;
using System.Collections;

public class HoleCollisionEndless : MonoBehaviour {
	private PlayerEndless player;
	
	void Start () {
		player = FindObjectOfType(typeof (PlayerEndless)) as PlayerEndless;
	}
	
	void OnTriggerEnter2D (Collider2D other) {
		if(other.transform.gameObject.tag == "void") {
			player.Die();
		}
	}
}
