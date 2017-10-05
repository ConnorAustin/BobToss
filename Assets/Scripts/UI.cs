using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {
	public RectTransform backBar;
	public RectTransform bar;
    public Text balls;
    public Text won;
    public Text lose;
    public GameObject paused;

    void Start () {
		
	}
	
	void Update () {
        var gm = GameManager.manager;
		float coverage = gm.coverage;
		float barWidth = Mathf.Lerp (0, backBar.sizeDelta.x, coverage);
		bar.sizeDelta = new Vector2 (barWidth, backBar.sizeDelta.y);
        balls.text = "Balls Left: " + gm.balls;

        if (gm.state == State.Won)
        {
            won.enabled = true;
            lose.enabled = false;
        }

        if (gm.state == State.Lose)
        {
            won.enabled = false;
            lose.enabled = true;
        }

        if (gm.state == State.Paused)
        {
            paused.SetActive(true);
        }
        else
        {
            paused.SetActive(false);
        }
    }
}
