using UnityEngine;
using System.Collections;

public class Ant : MonoBehaviour {
	
	private float left = 0.1f;
	private float right = 3.9f;
	private float range = 4.0f;
	
	//private SpriteRenderer spriteRenderer;
	//private Transform upCheck;
	
	Animator anim;
	//public bool dead;
	//public bool hitUp;
	//public bool showRays = false;
	
	
	// Use this for initialization
	void Start (){ 
		anim = GetComponent<Animator> ();
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
	
	
	
	//void OnTriggerEnter(Collider other) 
	//{
	//	if (other.gameObject.tag == "test") 
	//	{
	//		rigidbody.velocity = Vector3.zero;
			
	//	}
	//}
	
	void OnCollisionEnter2D(Collision2D other) {
		if (other.transform.gameObject.name == "Swiper") {
			
			//anim.Play ("AntDead");
			//spriteRenderer.sprite = deadAnt;
			anim.SetBool("dead", true);

			Destroy (gameObject, 0.5f);

			//Ray ray =  new Ray(transform.position, Vector3.up);
			//bool hitUp = Physics.Raycast(ray);
			//if(hitUp){
			//	anim.SetBool("dead", true);
			//	Destroy (gameObject); // If collision is with Swiper, destroy the coin immediately.
			//}
		}
	}
	
	
}

