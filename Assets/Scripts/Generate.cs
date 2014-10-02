using UnityEngine;
using System.Collections;

public class Generate : MonoBehaviour {

	public GameObject coin;

	// Use this for initialization
	void Start() {
		CreateCoins();
	}
	
	// Update is called once per frame
	void Update() {
	
	}

	// Method to create clones of coin in custom locations. The Vector2 objects are absolute x and y.
	void CreateCoins() {
		Instantiate (coin, new Vector2(-4,-4), Quaternion.identity);
		Instantiate (coin, new Vector2(-1,-3), Quaternion.identity);
		Instantiate (coin, new Vector2(1,-4), Quaternion.identity);
		Instantiate (coin, new Vector2(3,-3), Quaternion.identity);
		Instantiate (coin, new Vector2(5,-4), Quaternion.identity);
		Instantiate (coin, new Vector2(5,0), Quaternion.identity);
	}
}
