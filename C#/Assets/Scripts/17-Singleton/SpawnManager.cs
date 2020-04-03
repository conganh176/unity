using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Singleton
{
    public class SpawnManager : MonoBehaviour
    {
        private static SpawnManager _instance;
        public static SpawnManager Instance
        {
            get
            {
                if (_instance == null)
                    Debug.LogError("SpawnManager is null");

                return _instance;
            }
        }

        private void Awake()
        {
            _instance = this;
        }

        public void Spawn(string monster)
        {
            Debug.Log(monster + " spawned");
        }
    }
}
