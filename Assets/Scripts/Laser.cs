using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

	private Rigidbody2D rb;

	public GameObject ExplosionObject;
	public float Speed = 5f;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate () {
		rb.velocity = Vector2.up * Speed;
	}

	void OnTriggerEnter2D (Collider2D coll) {
		if (coll.name == "Main Camera") {
			GameObject.Destroy (this.gameObject);
		}

		if (coll.CompareTag ("Meteor")) {
			coll.transform.GetComponent<Meteor> ().Hit ();
			GameObject.Destroy (this.gameObject);
			GameObject.Instantiate (ExplosionObject, this.transform.position, Quaternion.identity);
		}
	}
}
