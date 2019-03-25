using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	private Rigidbody2D rb;
	private float shootTimer = 0;

	public GameObject ExplosionObject;
	public GameObject LaserObject;
	public float Speed = 4f;
	public float MinTimeToShoot = 1f;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	void Update () {
		if (shootTimer < MinTimeToShoot) {
			shootTimer += Time.deltaTime;
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			Shoot ();
		}
	}

	void FixedUpdate () {
		Vector2 dir = Vector2.zero;

		if (Input.GetKey (KeyCode.W)) {
			dir.y = 1;
		} else if (Input.GetKey (KeyCode.S)) {
			dir.y = -1;
		} 

		if (Input.GetKey (KeyCode.A)) {
			dir.x = -1;
		} else if (Input.GetKey (KeyCode.D)) {
			dir.x = 1;
		}

		rb.velocity = dir * Speed;
	}

	void Shoot () {
		if (MinTimeToShoot > shootTimer)
			return;

		shootTimer = 0;
		if (LaserObject != null) {
			Vector3 pos = this.transform.position;
			GameObject.Instantiate (LaserObject, pos, Quaternion.identity);
		}
	}


	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.CompareTag ("Meteor")) {
			GameObject.Instantiate (ExplosionObject, this.transform.position, Quaternion.identity);
			GameObject.Destroy (this.gameObject);
			GameObject.Find ("MainCamera").GetComponent<MainCameraScript> ().ShowRestartBtn ();
		}
	}
}
