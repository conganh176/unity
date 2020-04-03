using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    int _health { get; set; }

    void Damage();
}
