using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplatExplosion : MonoBehaviour {
	public float timeToDie;

	Material mat;
	float cutoff = 0;
	float scale = 0.1f;
	Transform splatExplosion;

	void Start () {
		splatExplosion = transform.Find ("SplatExplosion");
		mat = splatExplosion.GetComponent<Renderer> ().material;
		Invoke("PleaseDie", timeToDie);
	}

	void PleaseDie() {
		// okay...
		Destroy(gameObject);
	}
	
	void Update () {
		cutoff += 1.9f * Time.deltaTime;
		mat.SetFloat ("_SplatCutoff", cutoff);
		scale += 6.0f * Time.deltaTime;
		splatExplosion.localScale = Vector3.one * scale;
	}
}
