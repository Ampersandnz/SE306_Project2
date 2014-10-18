using UnityEngine;
using System.Collections;

public class SnowEndOfLevelSymbol : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		// this object was clicked - do something
		Application.LoadLevel("StoryLevel3");	
		StoryLevelSelect.currentLevel = 2; 

	}
}
