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
		StoryLevelSelect.currentLevel = 3; 
		Application.LoadLevel("StoryLevel3");	

	}
}
