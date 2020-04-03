using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable
{
    [SerializeField] private GameObject _acidPrefab;
    public int _health { get; set; }

    public override void Inititate()
    {
        base.Inititate();
        _health = base._health;
    }

    public void Damage()
    {
        if (_isAlive == true)
            _health--;

        if (_isAlive == false)
            return;

        if (_health <= 0)
        {
            _animator.SetTrigger("Dead");
            _isAlive = false;
            SpawnDiamond();
            Destroy(gameObject, transform.GetComponentInChildren<Animator>().GetCurrentAnimatorStateInfo(0).length);
        }
    }

    public void Attack()
    {
        Instantiate(_acidPrefab, transform.position, Quaternion.identity);
    }
    public override void CombatToMovement()
    {
        
    }
}
