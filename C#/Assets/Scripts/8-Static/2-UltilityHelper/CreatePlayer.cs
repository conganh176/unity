using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlayer : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UltilityHealper.CreateObject();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            UltilityHealper.SetPositionToZero(this.gameObject);
        }
    }
}
