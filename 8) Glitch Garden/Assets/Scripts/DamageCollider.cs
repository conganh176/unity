using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    [SerializeField] AudioClip playerDamage;

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        AudioSource.PlayClipAtPoint(playerDamage, Camera.main.transform.position, PlayerPrefbController.GetMasterVolume());

        FindObjectOfType<PlayerHealthDisplay>().loseHealth();
        Destroy(otherCollider.gameObject);
    }
}
