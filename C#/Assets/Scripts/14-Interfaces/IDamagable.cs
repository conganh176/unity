using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interfaces
{
    /*public interface IDamagable
    {
        int Health { get; set; }

        void Damage(int damageAmount);
        void Damage(float damageAmount);
    }*/
    public interface IDamagable<T>
    {
        int Health { get; set; }

        void Damage(T damageAmount);
    }
}
