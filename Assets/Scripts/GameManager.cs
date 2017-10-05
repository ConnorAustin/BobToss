using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum State {
    Playing,
    Paused,
    Won,
    Lose
}

public class GameManager : MonoBehaviour {
    public static GameManager manager;
    public GameObject staticStuff;
    
    [HideInInspector]
    public float coverage;

    public int balls;

    public float desiredCoverage;
    SplatCanvas[] canvases;
    public State state = State.Playing;

    void Start() {
        manager = this;
        var building = GameObject.Find("Building");
        canvases = building.GetComponentsInChildren<SplatCanvas>();
    }

    public void RecalculateCoverage() {
        coverage = 0;

        foreach (var sc in canvases)
        {
            coverage += sc.coverage;
        }
        coverage /= (float)canvases.Length;
        coverage /= desiredCoverage;
        coverage = Mathf.Min(1, coverage);
    }

    public void FiredBall() {
        balls -= 1;
        if (balls == 0)
            Invoke("GameOver", 2);
    }

    bool Won() {
        return coverage >= 0.99f;
    }

    void GameOver() {
        if (!Won())
        {
            state = State.Lose;
            Invoke("RestartTransition", 2);
        }
    }

    void RestartTransition()
    {
        staticStuff.SetActive(true);
        Invoke("Restart", 0.6f);
    }

    void VictoryTransition() {
        staticStuff.SetActive(true);
        Invoke("NextLevel", 1);
    }

    void NextLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Resume() {
        if(state == State.Paused)
            state = State.Playing;
        Time.timeScale = 1;
    }

    public void Exit()
    {
        Application.Quit();
    }

    void Update () {
        if (state != State.Won)
        {
            if (Won())
            {
                state = State.Won;
                Invoke("VictoryTransition", 4);
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (state == State.Playing)
            {
                state = State.Paused;
                Time.timeScale = 0;
            }
            else Resume();
        }
	}
}
