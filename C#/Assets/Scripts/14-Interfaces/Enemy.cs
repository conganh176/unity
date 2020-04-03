using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interfaces
{
    public class Enemy : MonoBehaviour, IDamagable<int>, IShoot
    {
        public int Health { get; set; }
        public void Damage(int damageAmount)
        {
            GetComponent<MeshRenderer>().material.color = Color.red;
        }
        public void Shoot()
        {

        }
    }
}
