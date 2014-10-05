using UnityEngine;
using System.Collections;

public class Life : MonoBehaviour {

	private PlayerStory player;
	private SpriteRenderer spriteRenderer;
	public Sprite transparent;
	public Sprite opaque;

	void Start() {
		player = FindObjectOfType(typeof(PlayerStory)) as PlayerStory;
		spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	public void MakeTransparent() {
		spriteRenderer.sprite = transparent;
		collider2D.enabled = false;
	}
	
	public void MakeOpaque() {
		spriteRenderer.sprite = opaque;
		collider2D.enabled = true;
	}
}