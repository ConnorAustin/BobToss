using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintDrip : MonoBehaviour {
	public float gravity;
	float vel = 0;

	void Start () {
		float randomWeight = Random.Range (1.2f, 2.0f);
		transform.localScale = transform.localScale * randomWeight;
		gravity += randomWeight * 0.2f;
	}
	
	void FixedUpdate () {
		vel += gravity;
		transform.position += Vector3.down * vel * Time.deltaTime;
	}
}
