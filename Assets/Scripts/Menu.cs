using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
    public Text[] textToFadeIn;
    public float fadeInDelay;
    public Image rosso;
    public GameObject staticStuff;

    Text curFadeIn;
    int currentFadeInIndex = -1;
    Vector3 desiredFadeInPos;
    bool fadeInRosso = false;

    void Start() {
        Invoke("StopStatic", 2);
    }

    void StopStatic() {
        Invoke("FadeIn", fadeInDelay);
        foreach (var t in textToFadeIn)
        {
            t.color = Color.clear;
        }
        rosso.color = new Color(1, 1, 1, 0);
        staticStuff.SetActive(false);
    }

    void FadeIn()
    {
        currentFadeInIndex++;
        if(currentFadeInIndex == textToFadeIn.Length - 1)
        {
            fadeInRosso = true;
            Invoke("Transition", 4);
        }
        if (currentFadeInIndex == textToFadeIn.Length)
        {
            return;
        }
        Invoke("FadeIn", fadeInDelay);
        curFadeIn = textToFadeIn[currentFadeInIndex];

        desiredFadeInPos = curFadeIn.transform.position;
        curFadeIn.transform.position += Vector3.down * 40;
    }

    void Transition() {
        Camera.main.GetComponent<AudioSource>().Stop();
        staticStuff.SetActive(true);
        Invoke("Next", 3);
    }

    void Next() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void FixedUpdate () {
        if (curFadeIn)
        {
            curFadeIn.transform.position = Vector3.Lerp(curFadeIn.transform.position, desiredFadeInPos, 0.05f);
            curFadeIn.color = Color.Lerp(curFadeIn.color, Color.black, 0.05f);
        }
        if(fadeInRosso)
        {
            rosso.color = Color.Lerp(rosso.color, Color.white, 0.05f);
        }
    }
}
