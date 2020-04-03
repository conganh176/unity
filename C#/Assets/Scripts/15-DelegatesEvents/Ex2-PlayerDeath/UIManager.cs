using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DelagatesEvents
{
    public class UIManager : MonoBehaviour
    {
        public int _deathCount;
        public Text _deathCountText;

        private void OnEnable()
        {
            Player._onDeath += UpdateDeathCount;
        }
        public void UpdateDeathCount()
        {
            _deathCount++;
            _deathCountText.text = "Death count: " + _deathCount;
        }
    }
}
