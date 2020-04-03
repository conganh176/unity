using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomClassEnum;

public class ItemDB : MonoBehaviour
{
    public List<CustomClassEnum.Item> itemDB = new List<CustomClassEnum.Item>();

    private void Start()
    {
        var itemIndex = Random.Range(0, itemDB.Count);
        Debug.Log("Item: " + itemDB[itemIndex].name);
        itemDB[itemIndex].Action();
    }
}
