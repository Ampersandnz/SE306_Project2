using UnityEngine;
using System.Collections;

public class MoveSpider : MonoBehaviour {
	public float percent_height;
	private Transform web_child;
	private Transform spider_child;
	private float height, startY;
	private float angle = 0;
	private float toDegrees = Mathf.PI / 180;
	// Use this for initialization
	void Start () {
		startY = transform.position.y;
		web_child = transform.FindChild ("web");
		spider_child = transform.FindChild ("spider");

		height = web_child.transform.localScale.y * percent_height / 100;

		web_child.transform.localScale = new Vector3(web_child.transform.localScale.x
		                                             ,height
		                                             ,web_child.transform.localScale.z);
	}
	// Update is called once per frame
	void Update () {
		angle += 1 * Time.deltaTime;

		if (angle > 360) {
			angle = 0;
		}
		float newY = Mathf.Cos (angle * toDegrees);// + startY - web_child.transform.localScale.y;
		spider_child.transform.position = new Vector2(spider_child.transform.position.x, newY);
	}
}
