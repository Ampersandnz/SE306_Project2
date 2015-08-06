using UnityEngine;
using System.Collections;

public class MoveSpider : MonoBehaviour {
	public float percent_height;
	private Transform web_child;
	private Transform spider_child;
	private float height, startY;

	// Use this for initialization
	void Start () {
		startY = transform.position.y;
		web_child = transform.FindChild ("web");
		spider_child = transform.FindChild ("spider_body");

		height = web_child.transform.localScale.y * percent_height / 100;

		web_child.transform.localScale = new Vector3(web_child.transform.localScale.x
		                                             ,height
		                                             ,web_child.transform.localScale.z);
	}
	// Update is called once per frame
	void Update () {
		if (spider_child == null) {
			if (web_child != null){
				Destroy (web_child.gameObject);
			}
		} else {
			float newY = Mathf.PingPong (Time.time, web_child.GetComponent<Collider2D>().bounds.size.y) + startY - web_child.GetComponent<Collider2D>().bounds.size.y;
			spider_child.transform.position = new Vector2(spider_child.transform.position.x, newY);
		}
	}
}
