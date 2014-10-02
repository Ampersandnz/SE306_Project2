using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {
	// Detect all collisions
	void OnCollisionEnter2D(Collision2D other) {
		if (other.transform.gameObject.name == "Swiper") {
			Destroy (gameObject); // If collision is with Swiper, destroy the coin immediately.
		}
	}
}
