using UnityEngine;
using System.Collections;

public class GenerateCoinsStoryLevel1 : MonoBehaviour {

	public GameObject coin = null;
	public GameObject life = null;

	// Use this for initialization
	void Start() {
		CreateCoins();
		CreateLives ();
	}

	// Method to create clones of coin in custom locations. The Vector2 objects are absolute x and y.
	void CreateCoins() {
		// Coins are commented out for now so we can test if the lives work.
		coin = Resources.Load("Coin") as GameObject;

		Instantiate (coin, new Vector2(-4,-4), Quaternion.identity);
		/*Instantiate (coin, new Vector2(-1,-3), Quaternion.identity);
		Instantiate (coin, new Vector2(1,-4), Quaternion.identity);
		Instantiate (coin, new Vector2(3,-3), Quaternion.identity);
		Instantiate (coin, new Vector2(5,-4), Quaternion.identity);
		Instantiate (coin, new Vector2(5,0), Quaternion.identity);*/
	}

	void CreateLives(){
		life = Resources.Load ("Life") as GameObject;

		Instantiate (life, new Vector2 (-1, -3), Quaternion.identity);
		Instantiate (life, new Vector2 (1, -4), Quaternion.identity);
		Instantiate (life, new Vector2 (3, -3), Quaternion.identity);
		Instantiate (life, new Vector2 (5, -4), Quaternion.identity);
		Instantiate (life, new Vector2 (5, 0), Quaternion.identity);
	}
}