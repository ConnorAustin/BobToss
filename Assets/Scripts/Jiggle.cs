using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jiggle : MonoBehaviour {
	public Transform root;

	public void DoneJigging() {
		root.GetComponent<Brush> ().DoneJigging ();
	}
}
