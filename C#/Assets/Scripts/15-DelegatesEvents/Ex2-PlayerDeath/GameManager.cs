using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DelagatesEvents
{
    public class GameManager : MonoBehaviour
    {
        private void OnEnable()
        {
            Player._onDeath += ResetPlayer;
        }
        public void ResetPlayer()
        {
            Debug.Log("Resetting Game");
        }
    }
}
