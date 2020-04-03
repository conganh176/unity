using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravestone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        Attackers attacker = otherCollider.GetComponent<Attackers>();

        if (attacker)
        {

        }
    }
}
