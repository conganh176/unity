using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    [SerializeField] int score = 0;
    [SerializeField] TMPro.TextMeshProUGUI livesText;
    [SerializeField] TMPro.TextMeshProUGUI scoreText;

    private void Awake()
    {
        int numberOfGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numberOfGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        livesText.text = "Live(s): " + playerLives.ToString();
        scoreText.text = "Score: " + score.ToString();
    }

    public void AddScore(int pointsToAdded)
    {
        score += pointsToAdded;
        scoreText.text = "Score: " + score.ToString();
    }

    public void ProcessPlayerDeath()
    {
        if (playerLives > 1)
        {
            TakeLife();
        }
        else
        {
            ResetGameSession();
        }
    }

    private void TakeLife()
    {
        playerLives--;
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        livesText.text = "Live(s): " + playerLives.ToString();
        GetComponent<AudioSource>().Play(0);
    }

    private void ResetGameSession()
    {
        SceneManager.LoadScene("Game Over Screen");
    }

    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
