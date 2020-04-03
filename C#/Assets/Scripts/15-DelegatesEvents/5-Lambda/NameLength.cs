using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DelagatesEvents.Lambda
{
    public class NameLength : MonoBehaviour
    {
        public Func<string, int> CharacterLength;

        private void Start()
        {
            string theName = "Kongu";
            CharacterLength = (name) => name.Length;
            int count = CharacterLength(theName);

            Debug.Log("Characters count: " + count);
        }
    }
}
