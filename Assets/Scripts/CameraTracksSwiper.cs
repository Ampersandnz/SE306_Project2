using UnityEngine;
using System.Collections;

public class CameraTracksSwiper : MonoBehaviour {
	
	Transform player;
	float offset;
	float offset_y;
	PlayerStory player_GO;
	
	// Use this for initialization
	void Start () {
		player_GO = FindObjectOfType (typeof(PlayerStory)) as PlayerStory;
		
		if (player_GO == null) {
			Debug.LogError ("No player!");
			return;
		}
		
		player = player_GO.transform;
		offset = transform.position.x - player.position.x;
		offset_y = transform.position.y - player.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (player != null && !player_GO.playerDead) {
			Vector3 pos = transform.position;
			pos.x = player.position.x + offset;
			if (player.position.y > 3f){
				pos.y = player.position.y + offset_y - 2f;
			}
			transform.position = pos;
		}
	}
}
