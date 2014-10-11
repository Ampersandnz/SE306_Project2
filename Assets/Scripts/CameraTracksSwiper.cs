using UnityEngine;
using System.Collections;

public class CameraTracksSwiper : MonoBehaviour {
	
	Transform player;
	float offset;
	PlayerStory player_GO;
	private Vector3 prev_pos;
	private Vector3 orig_pos;
	public bool move_back;


	// Use this for initialization
	void Start () {
		player_GO = FindObjectOfType (typeof(PlayerStory)) as PlayerStory;
		
		if (player_GO == null) {
			Debug.LogError ("No player!");
			return;
		}

		move_back = true;
		player = player_GO.transform;
		prev_pos = player.position;
		orig_pos = player.position;
		offset = transform.position.x - player.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		if (player != null && !player_GO.playerDead) {
//			if (player.position.x < prev_pos.x) {
//				move_back = false;
//			}
//			if (player.position.x > prev_pos.x) {
//				move_back = true;
			//			} && (Mathf.Approximately(diff, offset))
			float diff = transform.position.x - player.position.x;
			if (player.position.x > prev_pos.x) {
				Vector3 pos = transform.position;
				pos.x = player.position.x + offset;
				transform.position = pos;
			}
			prev_pos = player.position;

		}
	}
	
}
