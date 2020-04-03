using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    /*void Start()
    {
        Invoke("LoadFirstScene", 2f);
    }*/

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ReloadGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
}
