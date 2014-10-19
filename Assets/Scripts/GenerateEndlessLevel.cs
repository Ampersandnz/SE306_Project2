using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenerateEndlessLevel : MonoBehaviour {
	public GameObject[] availableChunks;
	public List<GameObject> currentChunks;
	private float screenWidthInPoints;

	// Use this for initialization
	void Start () {
		// Get references to all the chunks

		float height = 2.0f * Camera.main.orthographicSize;
		screenWidthInPoints = height * Camera.main.aspect;
	}
	
	void FixedUpdate () {
		GenerateChunkIfRequired();
	}

	public void AddChunk(float FarthestChunkEndX) {
		//1
		int randomChunkIndex = Random.Range(0, availableChunks.Length);
		
		//2
		GameObject chunk = (GameObject)Instantiate(availableChunks[randomChunkIndex]);
		
		//3
		float chunkWidth = chunk.transform.FindChild("void").localScale.x;
		
		//4
		float chunkCenter = FarthestChunkEndX + chunkWidth * 0.5f;
		
		//5
		chunk.transform.position = new Vector3(chunkCenter, 0, 0);
		
		//6
		currentChunks.Add(chunk);
	}

	void GenerateChunkIfRequired() {
		//1
		List<GameObject> chunksToRemove = new List<GameObject>();
		
		//2
		bool addChunks = true;        
		
		//3
		float playerX = transform.position.x;
		
		//4
		float removeChunkX = playerX - screenWidthInPoints;        
		
		//5
		float addChunkX = playerX + screenWidthInPoints;
		
		//6
		float farthestChunkEndX = 0;
		
		foreach(var chunk in currentChunks)
		{
			//7
			float chunkWidth = chunk.transform.FindChild("void").localScale.x;
			float chunkStartX = chunk.transform.position.x - (chunkWidth * 0.5f);    
			float chunkEndX = chunkStartX + chunkWidth;                            
			
			//8
			if (chunkStartX > addChunkX)
				addChunks = false;
			
			//9
			if (chunkEndX < removeChunkX)
				chunksToRemove.Add(chunk);
			
			//10
			farthestChunkEndX = Mathf.Max(farthestChunkEndX, chunkEndX);
		}
		
		//11
		foreach(var chunk in chunksToRemove)
		{
			currentChunks.Remove(chunk);
			Destroy(chunk);            
		}
		
		//12
		if (addChunks)
			AddChunk(farthestChunkEndX);
	}
}