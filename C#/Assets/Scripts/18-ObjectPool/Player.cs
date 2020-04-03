using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectPool
{
    public class Player : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameObject bullet = PoolManager.Instance.RequestBullet();
                bullet.transform.position = Vector3.zero;

            }
        }
    }
}
