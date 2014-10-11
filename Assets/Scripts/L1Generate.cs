﻿using UnityEngine;
using System.Collections;

// Class to generate items for level 1
public class L1Generate : MonoBehaviour {

	public GameObject coin;
	public GameObject life;

	// The array of x and y positions for our collectibles.
	float[][] positions = new float[][] {
		new float[] {26.6f, -3.75f},
		new float[] {28.59f, -1.3f},
		new float[] {30.92f, -3.75f}
	};

	public int random_location;
	
	void Start() {
		random_location = (int)(Random.value*positions.Length); // Select one random position to change into a life pack.
		CreateCollectibles ();
	}

	// Method to create clones of collectibles in all of our chosen locations.
	void CreateCollectibles() {
		for (int i=0; i<positions.Length; i++) {
			if(random_location.CompareTo (i)==0){
				CreateObject (life, positions[i][0], positions[i][1]);
			}else{
				CreateObject (coin, positions[i][0], positions[i][1]);
			}
		}
	}

	/* Method to create an object. Paramaters:
	 * 	- obj - The GameObject to clone.
	 * 	- x - The absolute x ordinate of the object.
	 * 	- y - The absolute y ordinate of the object.
	*/
	public void CreateObject(GameObject obj, float x, float y){
		Instantiate (obj, new Vector2 (x, y), Quaternion.identity);
	}
}