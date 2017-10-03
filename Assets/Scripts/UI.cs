using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {
	public RectTransform backBar;
	public RectTransform bar;

	void Start () {
		
	}
	
	void Update () {
		float coverage = GameManager.manager.coverage;
		float barWidth = Mathf.Lerp (0, backBar.sizeDelta.x, coverage);
		bar.sizeDelta = new Vector2 (barWidth, backBar.sizeDelta.y);
	}
}
