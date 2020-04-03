using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{
    [SerializeField] int level = 0;
    public void StartLevel()
    {
        SceneManager.LoadScene(level);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameSession>().DestroyGameObject();
    }
}
