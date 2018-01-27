using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public bool gameRunning = true;

    public float gameOverTimerLength;
    private float gameOverTimer = -1;

    public List<GameObject> children;

    public GameObject winner;

    // Use this for initialization
    void Start () {
        StartGame();
    }

    void StartGame() {
        gameRunning = true;
        winner = null;

        children = new List<GameObject>();
        foreach (Transform child in transform)
        {
           children.Add(child.gameObject);
        }
    }
	
	void Update () {
	   
        if(gameRunning)
        {
            CheckWinCondition();
        }
        else
        {
            if(gameOverTimer > 0)
            {
                gameOverTimer -= Time.deltaTime;
                if (gameOverTimer <= 0)
                {
                    EndGame();
                }
            }
        }
	}

    void CheckWinCondition()
    {
        if(this.children.Count == 1)
        {
            PlayerHealth ph = this.children[0].GetComponent<PlayerHealth>();
            if (!ph) return;
            if (ph.alive == false)
            {
                SetWinner(null);
            }
            return;
        }

        int aliveCount = 0;
        int aliveIndex = -1;
        for (int i = 0; i < this.children.Count; i++)
        {
            PlayerHealth ph = this.children[i].GetComponent<PlayerHealth>();
            if (!ph) return;
            if (ph.alive)
            {
                aliveCount++;
                aliveIndex = i;
            }
        }

        if(aliveCount == 1)
        {
            SetWinner(children[aliveIndex]);
        }
    }

    void EndGame()
    {
        Debug.Log("GameEnded");
        if(winner)
        {
            // winner
        }
        else
        {
            // draw
        }
    }

    void SetWinner(GameObject _winner)
    {
        winner = _winner;
        gameRunning = false;
        gameOverTimer = gameOverTimerLength;
    }
}
