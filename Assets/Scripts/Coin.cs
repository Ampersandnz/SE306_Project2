using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Collide with Swiper
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.transform.gameObject.name == "Swiper") {
			Destroy (gameObject);
		}
	}
}
