using UnityEngine;
using System.Collections;

public class Generate : MonoBehaviour {

	public GameObject peso;

	// Use this for initialization
	void Start () {
		CreateCoin ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void CreateCoin(){
		Instantiate (peso, new Vector2(-1,-3), Quaternion.identity);
		Instantiate (peso, new Vector2(1,-4), Quaternion.identity);
		Instantiate (peso, new Vector2(3,-3), Quaternion.identity);
		Instantiate (peso, new Vector2(5,-4), Quaternion.identity);
		Instantiate (peso, new Vector2(5,0), Quaternion.identity);
	}
}
