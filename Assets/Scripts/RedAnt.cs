using UnityEngine;
using System.Collections;

public class RedAnt : MonoBehaviour {
	private PlayerStory player;
	public float leftLimit;
	public float rightLimit;
	public int direction; // Direction of movement. 1 is left and -1 is right.

	public GameObject coin;
	public GameObject Swiper;

	public bool alive;
	public bool Hit1 = false;
	public bool Hit2 = false;
	public int hitCount;
	private SoundPlayer soundPlayer;
	Animator anim;

	//public int pathCount;
	//public Vector2[] GetPath(int i);

	//public var minX = Mathf.Infinity;
	//public var maxX = -Mathf.Infinity;
	//var minY = Mathf.Infinity;
	//var maxY = Mathf.Infinity;

	void Start () {
		alive = true;
		anim = GetComponent<Animator> ();

		/*var antRenderer = GetComponent<Renderer>();
		float antHeight = antRenderer.bounds.size.y;
		//float width = renderer.bounds.size.x;
		var swiperRenderer = Swiper.GetComponent<Renderer>();
		float swiperHeight = swiperRenderer.bounds.size.y;

		float ant = antRenderer.bounds.size.x;
	
		float swiper= swiperRenderer.bounds.size.x;
		print ("swiperheight" + swiperHeight);
		print ("antheight:" + antHeight);

		print ("swiper" + swiper);
		print ("ant:" + ant);

		print (swiperRenderer.bounds.min.y);
		print ("height:"+ antRenderer.bounds.max.y);

		print (swiperRenderer.bounds.max.y);
		print ("height:"+ antRenderer.bounds.min.y);*/
		
		
		//float toTop = swiper - transform.position.y;
		//print ("toTop:" + toTop);

		//Instantiate (coin, new Vector2 (-6, -3), Quaternion.identity);
		// Getting reference to player object.
		player = FindObjectOfType(typeof(PlayerStory)) as PlayerStory;
		
		// Setting default values for the left and right limits.
		leftLimit = -1;
		rightLimit = 1;
		direction = 1;
		
		// Setting up sound player.
		soundPlayer = FindObjectOfType(typeof(SoundPlayer)) as SoundPlayer;
		DontDestroyOnLoad (soundPlayer);
	}
	
	void Update () {
		// If red ant lose one live, then:
		if (Hit1 == true) {
			anim.SetBool ("hit1", true); // Change to "dead ant" texture.

			//transform.localScale = new Vector2(0.3f , 0.3f);
			if (transform.position.x > rightLimit) {
				direction = 1;
				transform.localScale = new Vector2(0.6f , 0.6f); // Flip sprite horizontally
			} else if (transform.position.x < leftLimit) {
				direction = -1;
				transform.localScale = new Vector2(-0.6f , 0.6f); // Flip sprite horizontally
			}
			transform.position = new Vector2 (transform.position.x + (-0.02f * (float)direction), transform.position.y);
			//collider2D.enabled = false; // Make ant intangible so Swiper can't collide with the carcass.
			//Hit1 = false;

		} 

		// if ant dead
		else if(Hit2 == true){
			anim.SetBool ("hit2", true); // Change to "dead ant" texture.
			collider2D.enabled = false;
			var positionX = transform.position.x;
			var positionY = transform.position.y;

			Destroy (gameObject, 0.5f);

			//Invoke("CreateObject", 3.0f);
			CreateObject (coin, positionX+1.2f, positionY+3.0f);
			//Instantiate (coin, new Vector2 (positionX, positionY), Quaternion.identity);
			Hit2 = false;
		}

		else {
			
			// Moving left and right
			if (transform.position.x > rightLimit) {
				direction = 1;
				transform.localScale = new Vector2(0.6f , 0.6f); // Flip sprite horizontally
			} else if (transform.position.x < leftLimit) {
				direction = -1;
				transform.localScale = new Vector2(-0.6f , 0.6f); // Flip sprite horizontally
			}
			transform.position = new Vector2 (transform.position.x + (-0.02f * (float)direction), transform.position.y);
			
		}
	}
	
	void OnCollisionEnter2D(Collision2D other) {
		
		// If collision is with Swiper, check if it is dead.
		if (other.transform.gameObject.name == "Swiper") {

			/*var minX = Mathf.Infinity;
			var maxX = -Mathf.Infinity;
			var minY = Mathf.Infinity;
			var maxY = Mathf.Infinity;
			
			var poly = Swiper.GetComponent(BoxCollider2D);
			for (var i = 0; i < poly.pathCount; i++) {
				//var path = Vector2;
				var path = poly.GetPath(i);
				//for (var v = path) {
				path = transform.TransformPoint(path);
				if (path[0] < minX){ 
					minX = path[0];
				}
				if (path[1] < minY){
					minY = path[1];
				}
				if (path[0] > maxX){
					maxX = path[0];
				}
				if (path[1] > maxY){
					maxY = path[1];
				}
			} */
			 
			//var top = transform.position.y - minY;  
			//var Totop = maxY - transform.position.y;

			//var antRenderer = GetComponent<Renderer>();
			//float antHeight = antRenderer.bounds.size.y;
			//float width = renderer.bounds.size.x;
			//var swiperRenderer = Swiper.GetComponent<Renderer>();
			//float swiperHeight = swiperRenderer.bounds.size.y;

			/*float swiperToButtom = swiperHeight/4.0f;
			float antToTop = antHeight/4.0f;

			float a = Swiper.transform.position.y - swiperToButtom;
			float b = transform.position.y + antToTop;
			print (swiperRenderer.bounds.min.y);
			print ("height:"+ antRenderer.bounds.max.y);*/

			var colliderSwiper = Swiper.GetComponent<BoxCollider2D>();
			var colliderS = colliderSwiper.collider2D;
			//int width = collider.bounds.size.x;
			var colliderAnt = GetComponent<BoxCollider2D>();
			var colliderA = colliderAnt.collider2D;
				
				//if (player.transform.position.y - swiperToButtom >= transform.position.y + antToTop) {
			//print (colliderS.bounds.min.y);
			//print ("height:"+ colliderA.bounds.max.y);

			if (colliderS.bounds.min.y >= colliderA.bounds.max.y){
				Hit1 = false;
				Hit2 = false;
				//alive = true;
				hitCount++;

				var Sx = Swiper.transform.position.x;
				var Sy = Swiper.transform.position.y;
				
				if(hitCount == 1){
					Hit1 = true;
					Swiper.transform.position = new Vector2(Sx, Sy+3.0f);
				}

				if (hitCount == 2){
					//Hit1 = false;
					Hit2 = true;
					hitCount = 0;
					soundPlayer.PlaySoundEffect("crunch");
					Swiper.transform.position = new Vector2(Sx, Sy+3.0f);
				}

			}
		}
	}

	/* Method to create an object. Paramaters:
	 * 	- obj - The GameObject to clone.
	 * 	- x - The absolute x ordinate of the object.
	 * 	- y - The absolute y ordinate of the object.
	*/
	public void CreateObject(GameObject obj, float x, float y){
		Instantiate (obj, new Vector2 (x, y), Quaternion.identity);
	}

//	public void SetMinMaxPoly2D() {

		/*var minX = Vector2;
	 	var minY = Vector2;
		var maxX = Vector2;
		var maxY = Vector2;

		//var path = Vector2;
		//var v = Vector2;

		minX = Vector2(Mathf.Infinity,0);
		minY = Vector2(0,Mathf.Infinity);
		maxX = Vector2(-Mathf.Infinity,0);
		maxY = Vector2(0,-Mathf.Infinity);*/

//	}
}
