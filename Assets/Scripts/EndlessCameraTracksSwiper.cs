using UnityEngine;
using System.Collections;

public class EndlessCameraTracksSwiper : MonoBehaviour {
	
	Transform player;
	float threshold;
	float offset1;
	float offset2;
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

		offset2 = 3;
		threshold = -3f;
	}
	
	// Update is called once per frame
	void Update () {
		if (player != null && !player_GO.playerDead) {
			Vector3 pos = transform.position;
			pos.x = player.position.x + offset1 + 9;
			if(player.position.y > threshold) {
				pos.y = player.position.y + offset1 - offset2;
			}
			transform.position = pos;
		}
	}
}
