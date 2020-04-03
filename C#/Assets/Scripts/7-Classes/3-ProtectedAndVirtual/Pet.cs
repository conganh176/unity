using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet : MonoBehaviour
{
    protected string petName;       //only access via the inheritance of this

    protected virtual void Speak()      //overwrite function inheritance of this
    {
        Debug.Log("Speak!!!");
    }

    private void Start()
    {
        Speak();    //used all Speak() function of children
    }
}
