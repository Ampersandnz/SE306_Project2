using UnityEngine;
using System.Collections;

public class Ant : MonoBehaviour {

	public float leftBoundary;
	public float rightBoundary;

	public float speed = 1;
	private bool move = true;

	private float pos;

	// Use this for initialization
	void Start () {
		pos = Random.Range (-4, 4);
	}
	
	// Update is called once per frame
	void Update () {
//		new Vector3(Mathf.PingPong (Time.time, 4), Vector3.up, transform.position.z));
		pos -= Time.deltaTime;
		transform.LookAt (Vector3.Slerp (Vector3.left, Vector3.right, Mathf.PingPong (pos, 10.0f)));
//			
	}

	void FixedUpdate(){
//		transform.Translate (transform.right * speed * Time.deltaTime);
//		rigidbody.transform.Translate (transform.forward * speed * Time.deltaTime);

		Vector3 pos = new Vector3 (-4f, 0f, 0f);

//		transform.position = pos;

//		transform.Translate (pos * Time.deltaTime);




//		rigidbody.AddForce (pos * Time.deltaTime);


//		transform.Translate (Vector3.zero);

	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.tag == "test") 
		{
			rigidbody.velocity = Vector3.zero;
		}
		
	}



}
