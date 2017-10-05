using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Advertisement : MonoBehaviour {
    public string advertAnimation;
    public AudioClip introSnd;
    public AudioClip advertSnd;
    public GameObject staticStuff;

    public GameObject advertisement;
    public Text text;

    void Start () {
        Invoke("ShowAdvertisement", 5);
	}

    void ShowAdvertisement()
    {
        advertisement.SetActive(true);
        GetComponent<Animator>().Play(advertAnimation);
        Camera.main.GetComponent<AudioSource>().Stop();
        Camera.main.GetComponent<AudioSource>().clip = advertSnd;
        Camera.main.GetComponent<AudioSource>().Play();
        Invoke("Stop", 4);
    }

    void Stop() {
        advertisement.SetActive(false);
        Camera.main.GetComponent<AudioSource>().Stop();
        Camera.main.GetComponent<AudioSource>().clip = introSnd;
        Camera.main.GetComponent<AudioSource>().Play();
        text.text = "WE ARE BACK.";
        Invoke("Transition", 4);
    }

    void Transition() {
        staticStuff.SetActive(true);
        Invoke("NextLevel", 1);
    }

    void NextLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void Update () {
		
	}
}
