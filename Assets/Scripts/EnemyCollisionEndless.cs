using UnityEngine;
using System.Collections;

public class EnemyCollisionEndless : MonoBehaviour {
	private PlayerEndless playerStory;
	void Start() {
		playerStory = FindObjectOfType(typeof(PlayerEndless)) as PlayerEndless;
	}

	void OnTriggerEnter2D (Collider2D other) {
		AntEndless ant = other.gameObject.GetComponent<AntEndless>();
		if (ant != null && ant.alive) {
			ant.Die ();
			playerStory.rigidbody2D.AddForce(playerStory.enemyBounce);
			Physics2D.IgnoreCollision(other, playerStory.collider2D, true);
		}

		Spider spider = other.gameObject.GetComponent<Spider>();
		if (spider != null && spider.alive) {
			spider.Die();
			playerStory.rigidbody2D.AddForce(playerStory.enemyBounce);
			Physics2D.IgnoreCollision(other, playerStory.collider2D, true);
		}
	}
}
