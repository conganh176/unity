using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Abstracts
{
    public abstract class Enemy : MonoBehaviour     //Force inheritance
    {
        public int speed;
        public int health;
        public int gems;

        public abstract void Attack();      //class inheritance must implement this method

        public virtual void Die()
        {
            Destroy(this.gameObject);
        }
    }

    public class MossGiant : Enemy
    {
        public override void Attack()
        {
            throw new System.NotImplementedException();
        }

        public override void Die()
        {
            base.Die();
        }
    }
}
