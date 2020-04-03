using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DelagatesEvents.Actions
{
    public class UIManager : MonoBehaviour
    {
        public void OnEnable()
        {
            Player.OnDamageReceived += UpdateHealth;
        }
        public void UpdateHealth(int health)
        {
            Debug.Log("Current health: " + health);
        }
    }
}
