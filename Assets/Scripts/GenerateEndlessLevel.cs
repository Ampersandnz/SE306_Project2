using UnityEngine;
using System.Collections;

public class GenerateEndlessLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
		// Get references to all the segments
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void loadNextSegment() {
		// Called by PlayerEndless entering a trigger zone
		// Removes the oldest segment (now offscreen)
		// Adds in the next segment
	}
}
