using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DelagatesEvents.Lambda
{
    public class DelegateVoid : MonoBehaviour
    {
        public Action<int, int> Sum;    //parameter
        public Action onGetName;        //no parameter
        void Start()
        {
            Sum = (a, b) =>
            {
                var total = a + b;
                if (total < 100)
                {
                    Debug.Log(total + " is less than 100");
                }
            };
            Sum(6, 9);

            onGetName = () =>
            {
                Debug.Log("Name: " + gameObject.name);
            };
            onGetName();
        }
    }
}
