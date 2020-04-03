using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Items
{
    public int itemID;
    public string name;
    public string description;
}

public class Data : MonoBehaviour
{
    public Items[] myItems;
    private void Start()
    {
        foreach (var item in myItems)
        {
            Debug.Log(item.itemID);
        }
    }

    private void Update()
    {
        
    }
}
