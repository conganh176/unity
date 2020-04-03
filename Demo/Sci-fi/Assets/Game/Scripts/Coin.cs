using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private AudioClip _coinPickup;
    [SerializeField] private float _coinPickupSound = 0.5f;
    private void OnTriggerStay(Collider collision)
    {
        if (collision.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Player player = collision.GetComponent<Player>();
                if (player != null)
                {
                    player._hasCoin = true;
                    UIManager uimanager = GameObject.Find("Canvas").GetComponent<UIManager>();
                    if (uimanager != null)
                    {
                        uimanager.CollectCoin();
                    }
                    AudioSource.PlayClipAtPoint(_coinPickup, transform.position, _coinPickupSound);
                    Destroy(gameObject);
                }
            }
        }
    }
}
