using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameover : MonoBehaviour
{
    private void Awake()
    {
        FindObjectOfType<Player>().SetDeadStatus();
        FindObjectOfType<Player>().GetComponent<Animator>().SetTrigger("IsDead");
    }
}
