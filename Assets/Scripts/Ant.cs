using UnityEngine;
using System.Collections;

public class Ant : MonoBehaviour {

	private float left = 0.1f;
	private float right = 3.9f;
	private float range = 4.0f;

	// Use this for initialization
	void Start () {
	//	pos = Random.Range (-4, 4);
		//origX = transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {




		
		if (transform.position.x > right) {
			transform.localScale = new Vector3 (0.35f, 0.35f, 1);
		} else if (transform.position.x < left) {
			transform.localScale = new Vector3 (-0.35f, 0.35f, 1);

		}

		transform.position = new Vector3(Mathf.PingPong (Time.time, range), transform.position.y, transform.position.z);

	}

	void FixedUpdate(){


	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.tag == "test") 
		{
			rigidbody.velocity = Vector3.zero;
		}
		
	}



}
