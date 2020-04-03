using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DelagatesEvents.Return
{
    public class NameLength : MonoBehaviour
    {
        //public delegate int CharacterLength(string text);
        //CharacterLength length;

        public Func<string, int> CharacterLength;

        private void Start()
        {
            string name = "Kongu";

            /*length = GetCharacters;
            Debug.Log("Characters count: " + length(name));*/
            CharacterLength = GetCharacters;
            Debug.Log("Characters count: " + CharacterLength(name));
        }

        int GetCharacters(string name)
        {
            return name.Length;
        }
    }
}
