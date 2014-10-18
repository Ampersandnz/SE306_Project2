using UnityEngine;
using System.Collections;

public class CameraTracksSwiper : MonoBehaviour {
	
	Transform player;
	float threshold;
	float offset1;
	float offset2;
	string levelName;
	PlayerStory player_GO;
	
	// Use this for initialization
	void Start () {
		player_GO = FindObjectOfType (typeof(PlayerStory)) as PlayerStory;
		
		if (player_GO == null) {
			Debug.LogError ("No player!");
			return;
		}

		player = player_GO.transform;
		offset1 = transform.position.x - player.position.x;
		offset1 = transform.position.y - player.position.y;

		levelName = Application.loadedLevelName;
		if (levelName == "StoryLevel1") {
			threshold = 2.9f;
			offset2 = 0;
		} else if (levelName == "StoryLevel2") {
			threshold = -1.6f;
			offset2 = 3;
		} else if (levelName == "StoryLevel3") {
			threshold = -8.5f;
			offset2 = 3;
		}
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
