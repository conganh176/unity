using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dictionary
{
    public class ItemDB : MonoBehaviour
    {
        public Dictionary<int, Item> itemDictionary = new Dictionary<int, Item>();

        private void Start()
        {
            Item sword = new Item();
            sword.name = "Sword";
            sword.id = 0;

            Item bread = new Item();
            bread.name = "Bread";
            bread.id = 1;

            Item coin = new Item();
            coin.name = "Coin";
            coin.id = 2;

            Item key = new Item();
            key.name = "Key";
            key.id = 3;

            itemDictionary.Add(0, sword);
            itemDictionary.Add(1, bread);
            itemDictionary.Add(2, coin);
            itemDictionary.Add(3, key);

            foreach (KeyValuePair<int, Item> item in itemDictionary)
            {
                Debug.Log("Key: " + item.Key);
                Debug.Log("Item: " + item.Value.name);
            }

            if (itemDictionary.ContainsKey(3))
            {
                Debug.Log("You found the key");
            }
            else
            {
                Debug.Log("The key does not exist");
            }
        }
    }
}
