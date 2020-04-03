using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DelagatesEvents
{
    public class Cube : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Events._onClick += TurnRed;
        }

        public void TurnRed()
        {
            GetComponent<MeshRenderer>().material.color = Color.red;
        }

        private void OnDisable()
        {
            Events._onClick -= TurnRed;
        }
    }
}
