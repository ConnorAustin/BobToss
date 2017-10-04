using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplatCanvas : MonoBehaviour {
	public float coverage;

	void Start () {
        var mesh = GetComponent<MeshFilter>().mesh;

        var mesh_colors = new Color[mesh.vertices.Length];
        for(int i = 0; i < mesh.colors.Length; i++) {
            mesh_colors[i] = Color.clear;
        }
        mesh.colors = mesh_colors;
	}

    public void RecalculateCoverage() {
        float actualCoverage = 0;

        var mesh = GetComponent<MeshFilter>().mesh;
        for (int i = 0; i < mesh.colors.Length; i++)
        {
            actualCoverage += mesh.colors[i].a;
        }

        coverage = actualCoverage / (float)mesh.colors.Length;
        GameManager.manager.RecalculateCoverage();
    }
}
