using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplatExplosion : MonoBehaviour {
	Material mat;
	float cutoff = 0;
	float scale = 1;

	void Start () {
		mat = GetComponent<Renderer> ().material;	
	}
	
	void Update () {
		cutoff += 1.9f * Time.deltaTime;
		mat.SetFloat ("_SplatCutoff", cutoff);
		scale += 3.0f * Time.deltaTime;
		transform.localScale = Vector3.one * scale;
	}
}
