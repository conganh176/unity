using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DelagatesEvents
{
    public class Teleport : MonoBehaviour
    {
        public delegate void ToTeleport(Vector3 position);
        public static event ToTeleport _onTeleport;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (_onTeleport != null)
                {
                    Vector3 position = new Vector3(6, 9, 0);
                    _onTeleport(position);
                }
            }
        }
    }
}
