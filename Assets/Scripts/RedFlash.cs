using UnityEngine;
using System.Collections;
using System.Threading;

public class RedFlash : MonoBehaviour {
	public GUITexture red;
	// In milliseconds
	public int flash_time;

	void Start() {
		red.enabled = false;
	}

	public IEnumerator FlashOnHit() {
		print ("Flash on hit called!");
		red.enabled = true;
		Color color = red.color;

		for (int i = 0; i < 6; i++) {
			color.a = 0.06f * i;
			red.color = color;
			yield return new WaitForSeconds(((flash_time / 5) / 1000 ) / 2);
		}

		for (int i = 5; i > -1; i--) {
			color.a = 0.06f * i;
			red.color = color;
			yield return new WaitForSeconds(((flash_time / 5) / 1000 ) / 2);
		}
		
		red.enabled = false;
	}
}
