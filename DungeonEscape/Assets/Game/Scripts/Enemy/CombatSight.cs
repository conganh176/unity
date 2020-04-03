using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatSight : MonoBehaviour
{
    private Animator _animator;
    private Enemy _enemy;
    private bool _foundPlayer = false;
    private void Start()
    {
        _animator = transform.parent.GetComponent<Animator>();
        if (_animator == null)
        {
            Debug.LogError("Animator not founded");
        }

        _enemy = transform.parent.parent.GetComponent<Enemy>();
        if (_enemy == null)
        {
            Debug.LogError("Enemy not founded");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && _foundPlayer == false)
        {
            _foundPlayer = true;
            _enemy.StopMoving();
            _animator.SetTrigger("SetCombat");
            _animator.SetBool("InCombat", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && _foundPlayer == true)
        {
            _foundPlayer = false;
            _enemy.StartMoving();
            _animator.SetBool("InCombat", false);
        }
    }
}
