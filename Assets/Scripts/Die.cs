using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour {
	public float timeToDie;

	void Start () {
		Invoke ("PleaseDie", timeToDie);
	}

	void PleaseDie() {
		// okay...
		Destroy(gameObject);
	}
}
