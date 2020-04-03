using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectPool
{
    public class PoolManager : MonoBehaviour
    {
        private static PoolManager _instance;
        public static PoolManager Instance
        {
            get
            {
                if (_instance == null)
                    Debug.LogError("PoolManager is null");

                return _instance;
            }
        }

        private void Awake()
        {
            _instance = this;
        }

        [SerializeField] private GameObject _bulletContainer;
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private List<GameObject> _bulletPool;

        private void Start()
        {
            _bulletPool = GenerateBullets(10);
        }

        List<GameObject> GenerateBullets(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                GameObject bullet = Instantiate(_bulletPrefab);
                bullet.transform.parent = _bulletContainer.transform;
                bullet.SetActive(false);

                _bulletPool.Add(bullet);
            }

            return _bulletPool;
        }

        public GameObject RequestBullet()
        {
            //loop throught bullet list
            foreach(var bullet in _bulletPool)
            {
                if (bullet.activeInHierarchy == false)      //if bullet is available
                {
                    bullet.SetActive(true);
                    return bullet;
                }
            }

            //need to create a new bullet
            GameObject newBullet = Instantiate(_bulletPrefab);
            newBullet.transform.parent = _bulletContainer.transform;
            _bulletPool.Add(newBullet);

            return newBullet;
        }
    }
}
