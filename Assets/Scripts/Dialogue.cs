using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Dialogue : MonoBehaviour {
    public Text text;
    public Image dialogueNext;
    public string[] dialogue;
    public float delay;
    public AudioClip dialogueDone;
    public AudioClip dialogueNextSnd;
    int dialogueIndex = 0;
    int substringLen = 0;
    bool next = false;

	void Start () {
        Invoke("Print", 2);

        dialogueNext.enabled = false;
    }

    void Print() {
        if (substringLen < dialogue[dialogueIndex].Length)
        {
            substringLen += 1;

            Invoke("Print", delay);
            text.text = dialogue[dialogueIndex].Substring(0, substringLen);

            if(substringLen == dialogue[dialogueIndex].Length)
            {
                next = true;
                dialogueNext.enabled = true;
                Camera.main.GetComponent<AudioSource>().PlayOneShot(dialogueDone);
            }
        }
    }
	
	void Update () {
        if (next && (Input.anyKey || Input.GetMouseButtonDown(0))) {
            dialogueIndex += 1;
            if(dialogueIndex == dialogue.Length)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                substringLen = 0;
                Camera.main.GetComponent<AudioSource>().PlayOneShot(dialogueNextSnd);
                Print();
                next = false;
                dialogueNext.enabled = false;
            }
        }
    }
}
