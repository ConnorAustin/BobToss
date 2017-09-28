using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintDripper : MonoBehaviour {
	public GameObject paintDrip;

	Rigidbody rigidBody;

	void Start () {
		rigidBody = GetComponent<Rigidbody> ();	
		Drip ();
	}

	void Drip() {
		// The rigidbody has to be moving fast enough to drip
		const float velCutoff = 0.1f;

		Invoke ("Drip", 0.1f + Random.Range(0.0f, 0.3f));
		if (rigidBody.velocity.magnitude > velCutoff) {
			var drip = GameObject.Instantiate (paintDrip);
			drip.transform.position = transform.position;
		}
	}
}
