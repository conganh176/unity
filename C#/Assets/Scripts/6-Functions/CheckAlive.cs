using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAlive : MonoBehaviour
{
    [SerializeField] private bool _isDead = false;
    [SerializeField] private int _health = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isDead == false)
        {
            Damage(Random.Range(5, 20));
        }
    }

    private void Damage(int damageAmount)
    {
        _health -= damageAmount;

        if (IsDead())
        {
            Debug.Log("The player is dead");
            _health = 0;
        }
    }

    private bool IsDead()
    {
        return (_health < 1);
    }
}
