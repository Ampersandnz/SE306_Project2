using UnityEngine;
using System.Collections;

public class Boots : MonoBehaviour {

	float maxUpAndDown = 2;            // amount of meters going up and down
	public float speed = 100;          // up and down speed
	float angle = 0;            // angle to determine the height by using the sinus
	float toDegrees = Mathf.PI/180;    // radians to degrees
	float startY;
	bool toChange = true;
	float paused = 0;
	float timeDiff = 0;
	float boundary;
	public GameObject banana;
	public float timeDelay = 8;
	public float bananaInterval = 2;
	public GUIText text;


	// Use this for initialization
	void Start () {
		startY = transform.position.y;
		boundary = startY - maxUpAndDown;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (toChange) {
			angle += speed * Time.deltaTime;
			if (angle > 360) {
				angle -= 360;
				toChange = false;
			}	
		}


		float height = startY + maxUpAndDown * Mathf.Cos (angle * toDegrees );
//		text.text = "start:" + startY + "\nHeight:" + height + "\nPaused:" + paused;
		if (height == boundary){
			toChange = false;
			paused += Time.deltaTime;
			if(paused >= timeDelay){
				paused = 0;
				toChange = true;
			}

			if (paused >= 4 && timeDiff > bananaInterval){
				timeDiff = 0;
				Instantiate(banana,new Vector2(transform.position.x,transform.position.y),Quaternion.identity);
			}
			timeDiff += Time.deltaTime;

		}
		transform.position = new Vector3(3.9f, height,transform.position.z);
	}
}