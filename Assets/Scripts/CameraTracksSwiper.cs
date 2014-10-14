using UnityEngine;
using System.Collections;

public class CameraTracksSwiper : MonoBehaviour {
	
	Transform player;
	float offset;
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
		offset = transform.position.y - player.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (player != null && !player_GO.playerDead) {
			Vector3 pos = transform.position;
<<<<<<< HEAD
			pos.x = player.position.x + offset;
			pos.y = player.position.y + offset;
=======
			pos.x = player.position.x + offset+9;
			if(player.position.y>2.9){
				pos.y = player.position.y + offset;
			}
>>>>>>> feature/level1
			transform.position = pos;
		}
	}
}
