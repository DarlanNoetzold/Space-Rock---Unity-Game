using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorCreator : MonoBehaviour {

	public GameObject MeteorObject;
	public float MinTimeToCreate = 1f;
	public float MaxTimeToCreate = 3f;

	private float timeToNextCreation;
	private float countTimer;
	private float xMin;
	private float xMax;

	// Use this for initialization
	void Start () {
		float horizontalExtension = Camera.main.orthographicSize * Screen.width / Screen.height;
		xMin = -horizontalExtension * 0.8f;
		xMax = horizontalExtension * 0.8f;

		GenerateNextTime ();
	}
	
	// Update is called once per frame
	void Update () {
		countTimer += Time.deltaTime;
		if (countTimer >= timeToNextCreation) {
			countTimer = 0;
			GenerateNextTime ();

			Vector3 pos = transform.position;
			pos.x = Random.Range(xMin, xMax);
			GameObject.Instantiate (MeteorObject, pos, Quaternion.Euler(0, 0, Random.Range(0, 359)));
		}
	}

	void GenerateNextTime() {
		timeToNextCreation = Random.Range (MinTimeToCreate, MaxTimeToCreate);
	}
}
