using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour {

	private Rigidbody2D rb;
	private SpriteRenderer renderer;

	public GameObject ExplosionObject;
	public float Speed = 5f;
	public int Health = 3;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		renderer = GetComponent<SpriteRenderer> ();
	}
	

	void FixedUpdate () {
		rb.velocity = Vector2.down * Speed;
	}

	public void Hit () {
		Health -= 1;

		switch (Health) {
		case 2:
			renderer.color = Color.yellow;
			break;
		case 1:
			renderer.color = Color.red;
			break;
		default:
			renderer.color = new Color (122, 66, 6);
			break;
		}

		if (Health <= 0) {
			GameObject.Find ("MainCamera").GetComponent<MainCameraScript> ().AddPoints ();
			GameObject.Instantiate (ExplosionObject, transform.position, Quaternion.identity);
			GameObject.Destroy (this.gameObject);
		}
	}
}
