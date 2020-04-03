using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DelagatesEvents
{
    public class Delegates : MonoBehaviour
    {
        public delegate void ChangeColor(Color newColor);
        public ChangeColor _changeColor;

        public delegate void OnComplete();
        public OnComplete _onComplete;
        void Start()
        {
            _changeColor = UpdateColor;
            _changeColor(Color.blue);

            _onComplete += Task;
            _onComplete += Task2;
            _onComplete += Task3;
            _onComplete();
        }

        public void UpdateColor(Color newColor)
        {
            Debug.Log("Color changed to: " + newColor.ToString());
        }

        public void Task()
        {
            Debug.Log("Task 1 completed");
        }
        public void Task2()
        {
            Debug.Log("Task 2 completed");
        }
        public void Task3()
        {
            Debug.Log("Task 3 completed");
        }
    }
}