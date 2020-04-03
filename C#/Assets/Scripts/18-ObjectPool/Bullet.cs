using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectPool
{
    public class Bullet : MonoBehaviour
    {
        private void OnEnable()
        {
            Invoke("Hide", 1f);     //call Hide() in 1 second
        }

        private void Hide()
        {
            this.gameObject.SetActive(false);
        }
    }
}
