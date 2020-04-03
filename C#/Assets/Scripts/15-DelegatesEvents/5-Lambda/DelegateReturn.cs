using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DelagatesEvents.Lambda
{
    public class DelegateReturn : MonoBehaviour
    {
        public Func<int> onGetNameLength;   //no parameter
        public Func<int, int, int> onCalculateSum;  //parameter
        private void Start()
        {
            onGetNameLength = () => 
            { 
                return this.gameObject.name.Length; 
            };
            int characterCount = onGetNameLength();
            Debug.Log("Characters count: " + characterCount);

            onCalculateSum = (a, b) => 
            { 
                return a + b; 
            };
            var sum = onCalculateSum(6, 9);
            Debug.Log("Sum: " + sum);
        }
    }
}

