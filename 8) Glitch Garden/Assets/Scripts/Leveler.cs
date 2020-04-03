using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Leveler : MonoBehaviour
{
    int currentSceneIndex;
    [SerializeField] int waitTime = 2;

    //SFX
    [SerializeField] AudioClip clickSound;
    float mainVolume;

    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneIndex == 0)
        {
            StartCoroutine(WaitForTime());
        }

        //SFX
        mainVolume = PlayerPrefbController.GetMasterVolume();
    }

    IEnumerator WaitForTime()
    {
        yield return new WaitForSeconds(waitTime);
        LoadNextScene();
    }

    public void RestartScene()
    {
        ClickSound();
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadNextScene()
    {
        ClickSound();
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene("GameOverScreen");
    }

    public void LoadMenu()
    {
        ClickSound();
        Time.timeScale = 1;
        SceneManager.LoadScene("StartScreen");
    }

    public void LoadOption()
    {
        ClickSound();
        SceneManager.LoadScene("OptionScreen");
    }

    public void Quit()
    {
        ClickSound();
        Application.Quit();
    }

    public void ClickSound()
    {
        if (clickSound)
        {
            AudioSource.PlayClipAtPoint(clickSound, Camera.main.transform.position, mainVolume);
        }
    }
}
