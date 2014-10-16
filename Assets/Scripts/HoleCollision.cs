﻿using UnityEngine;
using System.Collections;

public class HoleCollision : MonoBehaviour {
	private PlayerStory player;
	
	void Start () {
		player = FindObjectOfType(typeof (PlayerStory)) as PlayerStory;
	}
	
	void OnTriggerEnter2D (Collider2D other) {
		if(other.transform.gameObject.tag == "Hole") {
			player.health = 0;
		}
	}
}