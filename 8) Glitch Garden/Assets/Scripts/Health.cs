using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] GameObject deathVFX;
    [SerializeField] AudioClip deathSFX;
    [SerializeField] AudioClip hitSFX;

    float delayDestroy = 1f;

    public void dealDamage(float damage)
    {
        health -= damage;

        if (hitSFX)
        {
            AudioSource.PlayClipAtPoint(hitSFX, Camera.main.transform.position, PlayerPrefbController.GetMasterVolume());
        }

        if (health <= 0)
        {
            DeathSFX();
            DeathVFX();
            Destroy(gameObject);
        }
    }

    private void DeathVFX()
    {
        if (!deathVFX)
        {
            return;
        }

        GameObject deathVFXObject = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(deathVFXObject, delayDestroy);
    }
    
    private void DeathSFX()
    {
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, PlayerPrefbController.GetMasterVolume());
    }
}
