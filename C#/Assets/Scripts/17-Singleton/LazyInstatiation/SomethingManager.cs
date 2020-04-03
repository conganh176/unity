using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Singleton
{
    public class SomethingManager : MonoBehaviour
    {
        private static SomethingManager _instance;
        public static SomethingManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    //Debug.LogError("SomethingManager is null");
                    GameObject go = new GameObject("Something Manager");
                    go.AddComponent<SomethingManager>();
                }

                return _instance;
            }
        }

        private void Awake()
        {
            _instance = this;
        }

        public void DisplayName()
        {
            Debug.Log("My name is Cong Anh");
        }
    }
}
