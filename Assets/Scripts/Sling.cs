using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sling : MonoBehaviour
{
    public float stretchResistance;
    public float restingWidth;
	public Transform startPoint;
	public GameObject paintDrip;
    public AudioClip stretch;

    LineRenderer lr;
    
    Splat curProjectile;
    AudioSource audio;

    void Start()
    {
        lr = GetComponent<LineRenderer>();
        audio = GetComponent<AudioSource>();
        Drip();
    }

    public void SlingProjectile(GameObject projectile)
    {
        curProjectile = projectile.GetComponent<Splat> ();
		lr.material = curProjectile.slingMat;
        audio.PlayOneShot(stretch);
    }

    public void FireProjectile() {
        Invoke("UnslingProjectile", 0.12f);
    }

    void UnslingProjectile() {
        curProjectile = null;
    }

	void Drip() {
		Invoke ("Drip", 0.5f + Random.Range(0.0f, 1.0f));
		if (!curProjectile)
			return;
		
		float dripLerpPos = Random.Range (0.0f, 1.0f);
		Vector3 dripPos = Vector3.Lerp (startPoint.position, curProjectile.transform.position, dripLerpPos);

		var drip = GameObject.Instantiate (paintDrip);
		drip.transform.position = dripPos;
		drip.GetComponent<SpriteRenderer> ().color = curProjectile.color;
	}

    void Update()
    {
        if (!curProjectile)
        {
            lr.positionCount = 0;
            return;
        }

        var slingPoints = new Vector3[2];

        slingPoints [0] = startPoint.position;
        
		slingPoints [1] = curProjectile.transform.position;

		lr.positionCount = slingPoints.Length;
        lr.SetPositions(slingPoints);

        float shrinkage = Vector3.Distance(transform.position, curProjectile.transform.position) / stretchResistance;
        shrinkage = Mathf.Max(1, shrinkage);
        lr.startWidth = restingWidth / shrinkage;
        lr.endWidth = restingWidth / shrinkage;
    }
}