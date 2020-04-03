using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Singleton
{
    public class UIManager : MonoBehaviour
    {
        private static UIManager _instance;
        public static UIManager Instance
        {
            get
            {
                if (_instance == null)
                    Debug.LogError("UIManager is null");

                return _instance;
            }
        }

        private void Awake()
        {
            _instance = this;
        }

        public void UpdateScore(int score)
        {
            GameManager.Instance.DisplayName();
            Debug.Log("The score is " + score);
        }
    }
}
