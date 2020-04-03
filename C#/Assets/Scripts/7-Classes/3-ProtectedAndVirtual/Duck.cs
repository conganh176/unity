using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck : Pet
{
    protected override void Speak()     //overwrite function of inheritance
    {
        Debug.Log("Quack");
    }
}
