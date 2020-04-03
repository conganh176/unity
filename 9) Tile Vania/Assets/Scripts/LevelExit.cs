using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 2f;
    [SerializeField] float levelExitSlowMo = 0.2f;

    //SFX
    [SerializeField] AudioClip levelCompleteSound;
    [SerializeField] [Range(0, 1)] float levelCompleteVolume = 0.5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (FindObjectOfType<Player>().CheckAlive())
        {
            StartCoroutine(LoadNextLevel());
        }
    }

    IEnumerator LoadNextLevel()
    {
        FindObjectOfType<GameSession>().GetComponent<AudioSource>().Stop();
        FindObjectOfType<Player>().GetComponent<AudioSource>().PlayOneShot(levelCompleteSound, levelCompleteVolume);
        Time.timeScale = levelExitSlowMo;
        yield return new WaitForSeconds(levelLoadDelay);
        Time.timeScale = 1f;        //Normal timescale

        //var currentIndex = SceneManager.GetActiveScene().buildIndex;
        //SceneManager.LoadScene(currentIndex + 1);
        SceneManager.LoadScene(0);
        FindObjectOfType<GameSession>().DestroyGameObject();
    }
}
