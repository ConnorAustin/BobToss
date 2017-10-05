using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour {
    public float speed;
    public float timeToDie;
    Vector3 direction;
    float mySpeed;
    float desiredScale;

	void Start () {
        Invoke("Shrink", timeToDie);
        mySpeed = speed * Random.Range(0.75f, 1.25f);
        float dirAngle = Random.Range(0, 2 * Mathf.PI);
        direction = new Vector3(Mathf.Cos(dirAngle), Mathf.Sin(dirAngle), 0);
        transform.localScale = Vector3.zero;
        desiredScale = Random.Range(0.3f, 1.0f);
    }

    void Shrink() {
        Invoke("Die", 1);
        desiredScale = 0;
    }

    void Die() {
        Destroy(gameObject);
    }

    void FixedUpdate()
    {
        transform.localScale = Vector3.one * Mathf.Lerp(transform.localScale.x, desiredScale, 0.1f);
        transform.position += direction * speed;
    }
}
