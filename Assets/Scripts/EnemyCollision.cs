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
			
			//the lowest position of swiper's collider box
			var colliderSwiper = GetComponent<BoxCollider2D>();
			var colliderS = colliderSwiper.collider2D;
			
			// the highest position of Ant's collider
			var colliderAnt = ant.GetComponent<BoxCollider2D>();
			var colliderA = colliderAnt.collider2D;

			if (colliderS.bounds.min.y + 0.2f >= colliderA.bounds.max.y) {
				ant.Die ();
				playerStory.rigidbody2D.AddForce(playerStory.enemyBounce);
				Physics2D.IgnoreCollision(other, playerStory.collider2D, true);
			}

		}
		
		RedAnt redAnt = other.gameObject.GetComponent<RedAnt>();
		if (redAnt != null && redAnt.hitCount < 2) {
			
			//the lowest position of swiper's collider box
			var colliderSwiper = GetComponent<BoxCollider2D>();
			var colliderS = colliderSwiper.collider2D;
			
			// the highest position of Ant's collider
			var colliderRedAnt = redAnt.GetComponent<BoxCollider2D>();
			var colliderRA = colliderRedAnt.collider2D;
			
			if (colliderS.bounds.min.y + 0.2f >= colliderRA.bounds.max.y) {
				redAnt.TakeDamage();
				playerStory.rigidbody2D.AddForce(playerStory.enemyBounce);

				if (redAnt.hitCount > 1 ){
					Physics2D.IgnoreCollision(other, playerStory.collider2D, true);
					Physics2D.IgnoreCollision(other, collider2D, true);
				}
			}

		}
		
		Spider spider = other.gameObject.GetComponent<Spider>();
		if (spider != null && spider.alive) {

			//the lowest position of swiper's collider box
			var colliderSwiper = GetComponent<BoxCollider2D>();
			var colliderSw = colliderSwiper.collider2D;
			
			// the highest position of Spider's collider
			var colliderSpider = spider.GetComponent<BoxCollider2D>();
			var colliderSp = colliderSpider.collider2D;

			if (colliderSw.bounds.min.y + 0.2f >= colliderSp.bounds.max.y) {
				spider.Die();
				playerStory.rigidbody2D.AddForce(playerStory.enemyBounce);
				Physics2D.IgnoreCollision(other, playerStory.collider2D, true);
			}

		}
	}
}