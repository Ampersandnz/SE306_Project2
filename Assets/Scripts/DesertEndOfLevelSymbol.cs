using UnityEngine;
using System.Collections;

public class DesertEndOfLevelSymbol : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		// this object was clicked - do something
		Application.LoadLevel("StoryLevel2");
		StoryLevelSelect.currentLevel = 2; 
	}
}
