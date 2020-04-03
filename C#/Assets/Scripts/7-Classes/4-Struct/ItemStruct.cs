using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct StructItem    //value type -- stack
{
    public string name;
    public int id;

    public StructItem(string name, int id)
    {
        this.name = name;
        this.id = id;
    }
}

public class AnItem  //reference type -- heap
{
    public string name;
    public int id;

    public AnItem(string name, int id)
    {
        this.name = name;
        this.id = id;
    }
}

public class ItemStruct : MonoBehaviour
{
    AnItem _sword = new AnItem("Sword", 1);     //class
    StructItem _bread;      //struct

    private void Start()
    {
        _bread.name = "Bread";
        _bread.id = 2;

        Debug.Log("Sword name: " + _sword.name);
        ChangeValue(_sword);        //changed
        Debug.Log("Sword name after changed: " + _sword.name);

        Debug.Log("Bread name: " + _bread.name);
        ChangeValue(_bread);        //unchanged
        Debug.Log("Bread name after changed: " + _bread.name);
    }

    void ChangeValue(StructItem structItem) //value type    
    {
        structItem.name = "Eaten Bread";
    }

    void ChangeValue(AnItem classItem)  //reference type
    {
        classItem.name = "Master Sword";
    }
}
