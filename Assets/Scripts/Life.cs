using UnityEngine;
using System.Collections;

// Class for life packs
public class Life : MonoBehaviour {
	Animator anim;

	// Getting reference to player object.
	void Start() {
		// Initialising things for texture change.
		anim = GetComponent<Animator> ();
	}

	// Turns heart translucent and non-interactible.
	public void MakeTransparent() {
		anim.SetBool ("isOpaque", false);
		collider2D.enabled = false;
	}

	// Turns heart opaque and interactible.
	public void MakeOpaque() {
		anim.SetBool ("isOpaque", true);
		collider2D.enabled = true;
	}
}