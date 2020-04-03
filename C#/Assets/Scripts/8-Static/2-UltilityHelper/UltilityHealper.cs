using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UltilityHealper
{
    public static void CreateObject()
    {
        GameObject.CreatePrimitive(PrimitiveType.Cube);
    }

    public static void SetPositionToZero(GameObject obj)
    {
        obj.transform.position = Vector3.zero;
    }
}
