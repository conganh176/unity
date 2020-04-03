using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DelagatesEvents
{
    public class Objects : MonoBehaviour
    {
        void Start()
        {
            Teleport._onTeleport += Spawn;
        }

        public void Spawn(Vector3 position)
        {
            transform.position = position;
        }

        private void OnDisable()
        {
            Teleport._onTeleport -= Spawn;
        }
    }
}
