using UnityEngine;
using System.Collections;

public class EnemyCollision : MonoBehaviour {
	void OnTriggerEnter2D (Collider2D other) {
		Ant ant = other.gameObject.GetComponent<Ant>();
		if (ant != null) {
			ant.alive = false;
		}

		Spider spider = other.gameObject.GetComponent<Spider>();
		if (spider != null) {
			spider.alive = false;
		}
	}
}
