using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DelagatesEvents
{
    public class Player : MonoBehaviour
    {
        public delegate void OnDeath();
        public static event OnDeath _onDeath;
        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Death();
            }
        }

        void Death()
        {
            /*GameObject.FindObjectOfType<GameManager>().ResetPlayer();
            GameObject.FindObjectOfType<UIManager>().UpdateDeathCount();*/  //replace with below is better

            if (_onDeath != null)
            {
                _onDeath();
            }
        }
    }
}
