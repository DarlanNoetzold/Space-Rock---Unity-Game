using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorExplosion : MonoBehaviour {

	private float lifeTime = 0;
	private ParticleSystem ps;

	void Start() {
		ps = GetComponentInChildren<ParticleSystem> ();
	}

	void Update () {
		lifeTime += Time.deltaTime;
		if (lifeTime >= ps.main.duration) {
			Destroy (this.gameObject);
		}
	}
}
