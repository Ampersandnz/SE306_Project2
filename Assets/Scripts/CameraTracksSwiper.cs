using UnityEngine;
using System.Collections;

public class CameraTracksSwiper : MonoBehaviour {
	
	Transform player;
	float offset;
	PlayerStory player_GO;
	private Vector3 prev_pos;

	// Use this for initialization
	void Start () {
		player_GO = FindObjectOfType (typeof(PlayerStory)) as PlayerStory;
		
		if (player_GO == null) {
			Debug.LogError ("No player!");
			return;
		}

		player = player_GO.transform;
		prev_pos = player.position;
		offset = transform.position.x - player.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		if (player != null && !player_GO.playerDead) {
			float diff = transform.position.x - player.position.x;
			if (player.position.x > prev_pos.x && diff < offset) {
				Vector3 pos = transform.position;
				pos.x = player.position.x + offset;
				transform.position = pos;
			}
			prev_pos = player.position;
		}
	}
	
}
