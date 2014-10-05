using UnityEngine;
using System.Collections;

public class CameraTracksSwiper : MonoBehaviour {

	Transform player;
	float offset;

	// Use this for initialization
	void Start () {
	
		GameObject player_go = GameObject.FindGameObjectWithTag ("Player");

		if (player_go == null) {
						Debug.LogError ("No player!");
						return;
				}

		player = player_go.transform;
		offset = transform.position.x - player.position.x;

	}
	
	// Update is called once per frame
	void Update () {

		if (player != null) {
						Vector3 pos = transform.position;
						pos.x = player.position.x + offset;
						transform.position = pos;
				}
	}
}
