using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    //[Tooltip("In seconds")] [SerializeField] float levelLoadDelay = 1f;
    [Tooltip("FX Prefab on player")] [SerializeField] GameObject deathFX;

    //private void OnCollisionEnter(Collision collision)
    //{
    //    print("collided");
    //}

    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
        deathFX.SetActive(true);
        //Invoke("ReloadScene", levelLoadDelay);      //Load level delay
    }

    private void StartDeathSequence()
    {
        SendMessage("OnPlayerDeath");
    }

    /*private void ReloadScene()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;    //normal speed
    }*/
}
