using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CustomClassEnum
{
    [System.Serializable]
    public class Item
    {
        public string name;
        public int id;
        public Sprite icon;

        public enum ItemType
        {
            None,       //0
            Weapon,     //1
            Consumable  //2
        }

        public ItemType itemType;

        public void Action()
        {
            switch(itemType)
            {
                case ItemType.Consumable:
                    Debug.Log("This is the consumable. Item Type: " + (int)ItemType.Consumable);
                    break;
                case ItemType.Weapon:
                    Debug.Log("This is the weapon. Item Type: " + (int)ItemType.Weapon);
                    break;
                case ItemType.None:
                    Debug.Log("This is nothing. Item Type: " + (int)ItemType.None);
                    break;
            }
        }
    }
}
