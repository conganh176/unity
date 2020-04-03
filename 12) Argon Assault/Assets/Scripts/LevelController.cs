using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject gameOverScene;
    [SerializeField] GameObject completeScene;

    // Start is called before the first frame update
    void Start()
    {
        gameOverScene.SetActive(false);
        completeScene.SetActive(false);
    }

    public void HandleGameOverScene()
    {
        gameOverScene.SetActive(true);
    }

    public void HandleCompleteScene()
    {
        completeScene.SetActive(true);
    }
}
