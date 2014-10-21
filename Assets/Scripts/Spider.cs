using UnityEngine;
using System.Collections;

// Class for the ant enemy.
public class Spider : MonoBehaviour {
	public GameObject coin;

	public bool alive;
	private SoundPlayer soundPlayer;
	
	void Start () {
		alive = true;
		
		// Setting up sound player.
		soundPlayer = FindObjectOfType(typeof(SoundPlayer)) as SoundPlayer;
		DontDestroyOnLoad (soundPlayer);
	}
	
	void Update () {
	}

	public void Die() {
		alive = false;
		soundPlayer.PlaySoundEffect ("crunch");
		Destroy (gameObject, 0.5f);
	}
}
