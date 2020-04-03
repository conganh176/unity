using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadSinglePlayer()
    {
        SceneManager.LoadScene("SinglePlayer");
    }
    public void LoadMultiPlayer()
    {
        SceneManager.LoadScene("MultiPlayer");
    }
}
