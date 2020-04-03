using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DelagatesEvents
{
    public class Events : MonoBehaviour
    {
        public delegate void ActionClick();
        public static event ActionClick _onClick;

        public void ButtonClick()
        {
            if (_onClick != null)
                _onClick();
        }
    }
}
