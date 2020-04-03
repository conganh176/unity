using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartButton()
    {
        Debug.Log("Work");
        SceneManager.LoadScene(1);
    }

    public void MenuButton()
    {

    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
