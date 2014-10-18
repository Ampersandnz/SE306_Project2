using UnityEngine;
using System.Collections;

public class EnemyCollision : MonoBehaviour {
	private PlayerStory playerStory;
	void Start() {
		playerStory = FindObjectOfType(typeof(PlayerStory)) as PlayerStory;
	}

	void OnTriggerEnter2D (Collider2D other) {
		Ant ant = other.gameObject.GetComponent<Ant>();
		if (ant != null && ant.alive) {
			ant.Die ();
			playerStory.rigidbody2D.AddForce(playerStory.enemyBounce);
			//Physics2D.IgnoreCollision(other, playerStory.collider2D, true);
		}

		RedAnt redAnt = other.gameObject.GetComponent<RedAnt>();
		if (redAnt != null && redAnt.hitCount < 2) {
			redAnt.TakeDamage();
			playerStory.rigidbody2D.AddForce(playerStory.enemyBounce);
			//Physics2D.IgnoreCollision(other, playerStory.collider2D, true);
		}

		Spider spider = other.gameObject.GetComponent<Spider>();
		if (spider != null && spider.alive) {
			spider.Die();
			playerStory.rigidbody2D.AddForce(playerStory.enemyBounce);
			//Physics2D.IgnoreCollision(other, playerStory.collider2D, true);
		}
	}
}
