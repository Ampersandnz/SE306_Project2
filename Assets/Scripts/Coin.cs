using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D other) {
		if (other.transform.gameObject.name == "Swiper") {
			Destroy (gameObject);
		}
	}
}
