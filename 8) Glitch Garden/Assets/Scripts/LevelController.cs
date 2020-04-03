using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;
    [SerializeField] float waitToLoad = 4f;

    [Header("SFX")]
    [SerializeField] AudioClip winSound;
    [SerializeField] AudioClip loseSound;
    float mainSoundVolume;
    AudioSource audioSource;

    int numberOfAttackers = 0;
    bool isLevelTimerFinished = false;

    private void Start()
    {
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
        mainSoundVolume = PlayerPrefbController.GetMasterVolume();
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = mainSoundVolume;
    }

    public void attackerSpawned()
    {
        numberOfAttackers++;
    }

    public void attackerDestroyed()
    {
        numberOfAttackers--;

        if (numberOfAttackers <= 0 && isLevelTimerFinished && FindObjectOfType<PlayerHealthDisplay>().checkHealth() > 0)
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);
        audioSource.Stop();
        AudioSource.PlayClipAtPoint(winSound, Camera.main.transform.position, mainSoundVolume);
        yield return new WaitForSeconds(waitToLoad);
        FindObjectOfType<Leveler>().LoadNextScene();
    }

    public void HandleLoseCondition()
    {
        loseLabel.SetActive(true);
        audioSource.Stop();
        AudioSource.PlayClipAtPoint(loseSound, Camera.main.transform.position, mainSoundVolume);
        Time.timeScale = 0;     //Stop game time
    }

    public void levelTimerFinished()
    {
        isLevelTimerFinished = true;
        stopSpawner();
    }

    private void stopSpawner()
    {
        AttackersSpawner[] spawnerArray = FindObjectsOfType<AttackersSpawner>();

        foreach(AttackersSpawner spawner in spawnerArray)
        {
            spawner.StopSpawning();
        }
    }
}
