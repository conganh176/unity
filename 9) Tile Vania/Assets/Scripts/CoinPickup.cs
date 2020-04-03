using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] AudioClip coinSound;
    [SerializeField] [Range(0, 1)] float coinSoundVolume = 0.5f;
    [SerializeField] int points = 100;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (FindObjectOfType<Player>().CheckAlive())
        {
            FindObjectOfType<GameSession>().AddScore(points);
            PlayCoinSound();
            Destroy(gameObject);
        }
    }

    public void PlayCoinSound()
    {
        // AudioSource.PlayClipAtPoint(coinSound, Camera.main.transform.position, coinSoundVolume);
        FindObjectOfType<Player>().GetComponent<AudioSource>().PlayOneShot(coinSound, coinSoundVolume);
    }
}
