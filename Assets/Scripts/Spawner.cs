using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public GameObject spawnObject;
    public float spawnDelay;
	
	void Start () {
        Invoke("Spawn", spawnDelay);		
	}

    void Spawn() {
        Invoke("Spawn", spawnDelay);
        var o = GameObject.Instantiate(spawnObject);
        o.transform.position = transform.position;
    }
}
