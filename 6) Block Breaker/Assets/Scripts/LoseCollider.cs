using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    //cached reference
    GameStatus gameStatus;
    Ball ball;

    private void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        ball = FindObjectOfType<Ball>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ball.SetBallStop();
        gameStatus.LoseLive();
        if (gameStatus.CheckLives() == 0)
        {
            SceneManager.LoadScene("Game Over");
        }
    }
}
