﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Singleton
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;
        public static GameManager Instance
        {
            get
            {
                if (_instance == null)
                    Debug.LogError("Game Manager is null");

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
