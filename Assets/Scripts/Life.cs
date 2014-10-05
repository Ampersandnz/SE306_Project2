using UnityEngine;
using System.Collections;

// Class for life packs
public class Life : MonoBehaviour {

	private PlayerStory player;
	private SpriteRenderer spriteRenderer;
	public Sprite transparent;
	public Sprite opaque;

	// Getting reference to player object.
	void Start() {
		player = FindObjectOfType(typeof(PlayerStory)) as PlayerStory;
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	// Turns heart translucent and non-interactible.
	public void MakeTransparent() {
		spriteRenderer.sprite = transparent;
		collider2D.enabled = false;
	}

	// Turns heart opaque and interactible.
	public void MakeOpaque() {
		spriteRenderer.sprite = opaque;
		collider2D.enabled = true;
	}
}