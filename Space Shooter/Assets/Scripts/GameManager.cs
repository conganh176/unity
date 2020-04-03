using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool _isGameOver = false;
    [SerializeField] private GameObject _pauseMenuPanel;
    private Animator _pauseAnimator;

    private void Start()
    {
        _pauseAnimator = _pauseMenuPanel.GetComponent<Animator>();
        _pauseAnimator.updateMode = AnimatorUpdateMode.UnscaledTime;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && _isGameOver == true)
        {
            SceneManager.LoadScene("SinglePlayer");
        }

        if (Input.GetKeyDown(KeyCode.Escape))       //quit games
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.Return))       //pause games
        {
            _pauseMenuPanel.SetActive(true);
            _pauseAnimator.SetTrigger("isPaused");
            Time.timeScale = 0f;
        }
    }

    public void GameOver()
    {
        _isGameOver = true;
    }

    public void Resume()
    {
        _pauseMenuPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
