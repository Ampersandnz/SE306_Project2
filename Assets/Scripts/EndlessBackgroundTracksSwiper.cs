using UnityEngine;
using System.Collections;

public class EndlessBackgroundTracksSwiper : MonoBehaviour {
	
	Transform player;
	float threshold;
	float offset1;
	float offset2;
	string levelName;
	PlayerEndless player_GO;
	
	// Use this for initialization
	void Start () {
		player_GO = FindObjectOfType (typeof(PlayerEndless)) as PlayerEndless;
		
		if (player_GO == null) {
			Debug.LogError ("No player!");
			return;
		}

		player = player_GO.transform;
		offset1 = transform.position.x - player.position.x;
		offset1 = transform.position.y - player.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (player != null && !player_GO.playerDead) {
			Vector3 pos = transform.position;
			pos.x = player.position.x + offset1 + 9;
			transform.position = pos;
		}
	}
}
