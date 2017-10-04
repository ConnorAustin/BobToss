using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public static GameManager manager;

	[HideInInspector]
	public float coverage;

	public float desiredCoverage;
	SplatCanvas[] canvases;

	void Start () {
		manager = this;
		var building = GameObject.Find ("Building");
		canvases = building.GetComponentsInChildren<SplatCanvas> ();
	}

    public void RecalculateCoverage() {
        Debug.Log("rere");
        coverage = 0;

        foreach (var sc in canvases)
        {
            coverage += sc.coverage;
        }
        coverage /= (float)canvases.Length;
        coverage /= desiredCoverage;
        coverage = Mathf.Min(1, coverage);
    }

    void Update () {
	    
	}
}
