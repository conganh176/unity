using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveWin : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(ActivateWin());
    }

    IEnumerator ActivateWin()
    {
        yield return new WaitForSeconds(0.5f);

        Time.timeScale = 0f;
        FindObjectOfType<PlayerController>().DisableControl();
        FindObjectOfType<MusicPlayer>().GetComponent<AudioSource>().Stop();
        FindObjectOfType<LevelController>().HandleCompleteScene();
    }
}
