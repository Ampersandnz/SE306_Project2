﻿using UnityEngine;
using System.Collections;

// Class for Boots the monkey.

public class Boots : MonoBehaviour{
	private float desiredY;
	public GameObject banana;
	public bool SwiperNear;
	private bool startedThrowing;
	private PlayerStory player;
	
	void Start(){
		SwiperNear = false;
		startedThrowing = false;
		player = FindObjectOfType(typeof(PlayerStory)) as PlayerStory;
		desiredY = 4.5f; // Setting the desired height that we want Boots to end up after emerging from the "ceiling".
	}

	void Update(){

		if (Mathf.Abs (transform.position.x - player.transform.position.x) >= 15) {
			SwiperNear = false;
			StopThrowingBananas();
		}

		if (SwiperNear == true) {
			if (transform.position.y > desiredY) { // This transformation makes Boots emerge from the "ceiling".
				transform.position = new Vector2 (transform.position.x, transform.position.y - 0.1f);
			}
		}else if(Mathf.Abs (transform.position.x - player.transform.position.x) < 15) {
			SwiperNear = true;
			StartThrowingBananas ();
		}
	}

	void StartThrowingBananas(){
		InvokeRepeating ("ThrowBanana", 1f, 2f); // Every 2 seconds, create and throw a banana.
		InvokeRepeating ("ThrowBanana", 1.05f, 2f);
		InvokeRepeating ("ThrowBanana", 1.1f, 2f);
		InvokeRepeating ("ThrowBanana", 1.15f, 2f);
		InvokeRepeating ("ThrowBanana", 1.2f, 2f);
		/*
		InvokeRepeating ("ThrowBanana", 1.25f, 2f);
		InvokeRepeating ("ThrowBanana", 1.3f, 2f);
		InvokeRepeating ("ThrowBanana", 1.35f, 2f);
		InvokeRepeating ("ThrowBanana", 1.4f, 2f);
		InvokeRepeating ("ThrowBanana", 1.45f, 2f);*/
		startedThrowing = true;
	}

	void StopThrowingBananas(){
		CancelInvoke ("ThrowBanana");
		startedThrowing = false;
	}

	// Method to throw a banana.
	void ThrowBanana(){
		if (startedThrowing && !player.levelFinished) {
			Instantiate (banana, new Vector2 (transform.position.x, transform.position.y - 2f), Quaternion.identity);
		}
	} 
}
