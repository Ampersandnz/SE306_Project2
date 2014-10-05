using UnityEngine;
using System.Collections;

public class Spiders : MonoBehaviour {

	public GameObject Swiper;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.transform.gameObject.name == "Swiper") {
		
			var SwiperY = Swiper.transform.position.y - 0.6f;
			var SpiderY = transform.position.y + 0.36f;
			
			if (SwiperY >= SpiderY) {
						
				Destroy (gameObject, 0.5f);

			}

		}
	}
}
