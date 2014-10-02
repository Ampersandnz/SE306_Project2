using UnityEngine;
using System.Collections;

public class AccelerometerInput : MonoBehaviour {

	// Read accelerometer input in the x direction
	void Update () {
		transform.Translate (Input.acceleration.x, 0, 0);
	}
}
