using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

	private float lifeTime = 0;

	void Update () {
		lifeTime += Time.deltaTime;
		if (lifeTime >= 0.8f) {
			Destroy (this.gameObject);
		}
	}
}
